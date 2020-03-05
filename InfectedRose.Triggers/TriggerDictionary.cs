using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace InfectedRose.Triggers
{
    public class TriggerDictionary
    {
        public Trigger[] Triggers { get; }
        
        private TriggerDictionary(Trigger[] triggers)
        {
            Triggers = triggers;
        }
        
        public static async Task<TriggerDictionary> FromDirectoryAsync(string path)
        {
            var entries = Directory.GetFiles(path, "*.lutriggers", SearchOption.TopDirectoryOnly);

            var collections = new TriggerCollection[entries.Length];

            var tasks = new Task[entries.Length];

            var serializer = new XmlSerializer(typeof(TriggerCollection));

            for (var i = 0; i < entries.Length; i++)
            {
                var index = i;

                tasks[index] = Task.Run(async () =>
                {
                    var entry = entries[index];

                    var fileSegments = Path.GetFileNameWithoutExtension(entry).Split('_');

                    var fileId = 0;

                    foreach (var filePath in fileSegments)
                    {
                        if (int.TryParse(filePath, out fileId)) break;
                    }
                    
                    if (fileId == default) return;

                    await using var stream = File.OpenRead(entry);

                    var triggerCollection = (TriggerCollection) serializer.Deserialize(stream);

                    collections[index] = triggerCollection;

                    foreach (var trigger in triggerCollection.Triggers)
                    {
                        trigger.FileId = fileId;
                    
                        Console.WriteLine($"TRIGGER: {trigger.Id}:{trigger.FileId}");
                    }
                });
            }

            await Task.WhenAll(tasks);

            var triggers = collections
                .Where(c => c != default)
                .SelectMany(c => c.Triggers)
                .ToArray();

            return new TriggerDictionary(triggers);
        }

        public Trigger this[int fileId, int triggerId] => Triggers.FirstOrDefault(
            t => t.FileId == fileId && t.Id == triggerId
        );
    }
}