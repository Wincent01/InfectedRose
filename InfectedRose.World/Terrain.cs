using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;
using InfectedRose.Terrain.Editor;

namespace InfectedRose.World
{
    [XmlRoot]
    public class Terrain
    {
        [XmlElement] public string FileName { get; set; } = "terrain.raw";

        [XmlElement] public string Name { get; set; } = "terrain";

        [XmlElement] public string Description { get; set; } = "terrain file";

        [XmlElement] public int Size { get; set; } = 2;

        [XmlElement] public float DefaultHeight { get; set; } = 200;

        [XmlElement] public string LightMap { get; set; } = "";

        [XmlElement] public string BlendMap { get; set; } = "";
        
        [XmlElement("Height")] public TerrainHeight[] Heights { get; set; } = new TerrainHeight[0];

        [XmlElement("Color")] public TerrainColor[] Colors { get; set; } = new TerrainColor[0];

        public async Task SaveAsync(string path)
        {
            var editor = await TerrainEditor.OpenEmptyAsync(new TerrainSettings
            {
                Size = Size,
                DefaultHeight = DefaultHeight
            });
            
            editor.Load();

            var heightBrush = new HeightBrush(editor);

            if (Heights != default)
            {
                foreach (var height in Heights)
                {
                    heightBrush.Size = height.Size;

                    heightBrush.Power = height.Power;

                    heightBrush.Apply(height.Position);
                }
            }

            if (Colors != default)
            {
                var colorBrush = new ColorBrush(editor);

                foreach (var color in Colors)
                {
                    colorBrush.Size = color.Size;

                    colorBrush.Color = color.Color;

                    colorBrush.Apply(color.Position);
                }
            }

            editor.Apply();

            if (File.Exists(LightMap))
            {
                Console.WriteLine($"Applying light map.");
            
                var data = await File.ReadAllBytesAsync(LightMap);

                foreach (var chunk in editor.Source.Chunks)
                {
                    chunk.Lightmap.Data = data;
                }
            }
            
            if (File.Exists(BlendMap))
            {
                Console.WriteLine($"Applying blend map.");

                var data = await File.ReadAllBytesAsync(BlendMap);

                foreach (var chunk in editor.Source.Chunks)
                {
                    chunk.Blendmap.Data = data;
                }
            }

            await editor.SaveAsync(Path.Combine(path, FileName));
        }
    }
}