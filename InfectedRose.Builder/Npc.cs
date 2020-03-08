using System.Linq;
using System.Xml.Serialization;
using InfectedRose.Database;
using InfectedRose.Database.Concepts;

namespace InfectedRose.Builder
{
    [XmlRoot]
    public class Npc
    {
        [XmlIgnore] public AccessDatabase Database { get; set; }

        [XmlElement] public int Lot { get; set; } = 20000;

        [XmlElement] public string Name { get; set; } = "npc";

        [XmlElement] public int InteractDistance { get; set; } = 5;
        
        [XmlElement] public CharacterStyle Style { get; set; } = new CharacterStyle();
        
        [XmlElement("Item")] public int[] Items { get; set; } = new int[1];
        
        [XmlElement("Mission")] public MissionEntry[] Missions { get; set; } = new MissionEntry[1];

        public void Build()
        {
            var concept = Database.CopyObject(12261, Lot);

            concept.Row["name"].Value = Name;
            concept.Row["interactionDistance"].Value = InteractDistance;

            var style = concept.FirstOrDefault(c => c.Id == ComponentId.MinifigComponent);

            if (style != default)
            {
                BuildCharacterStyle(style.Row);
            }

            var items = concept.FirstOrDefault(c => c.Id == ComponentId.InventoryComponent);

            if (items != default)
            {
                BuildItems(items.Row);
            }

            var missions = concept.FirstOrDefault(c => c.Id == ComponentId.MissionNPCComponent);

            if (missions != default)
            {
                BuildMissions(missions.Row);
            }

            var render = concept.FirstOrDefault(c => c.Id == ComponentId.RenderComponent);

            if (render != default)
            {
                BuildRender(render.Row);
            }
        }

        private void BuildCharacterStyle(Column row)
        {
            var type = typeof(CharacterStyle);

            foreach (var info in type.GetProperties())
            {
                var name = info.Name.ToLower();

                row[name].Value = info.GetValue(Style);
            }
        }

        private void BuildItems(Column row)
        {
            var key = row.Key;
            
            var table = Database["InventoryComponent"];
                
            table.Remove(row);
            
            foreach (var item in Items)
            {
                var entry = table.Create(key);

                entry["itemid"].Value = item;
                entry["count"].Value = 1;
                entry["equip"].Value = true;
            }
        }

        private void BuildMissions(Column row)
        {
            var key = row.Key;
                
            var table = Database["MissionNPCComponent"];
                
            table.Remove(row);

            foreach (var mission in Missions)
            {
                var entry = table.Create(key);

                entry["missionID"].Value = mission.MissionId;
                entry["offersMission"].Value = mission.Offers;
                entry["acceptsMission"].Value = mission.Accepting;
            }

            if (Missions.Any())
            {
                BuildIcons();
            }
        }

        private void BuildIcons()
        {
            var table = Database["mapIcon"];

            var row = table.Create(Lot);
            row["iconID"].Value = 1;
            row["iconState"].Value = 1;
            
            row = table.Create(Lot);
            row["iconID"].Value = 3;
            row["iconState"].Value = 2;
            
            row = table.Create(Lot);
            row["iconID"].Value = 4;
            row["iconState"].Value = 4;
            
            row = table.Create(Lot);
            row["iconID"].Value = 6;
            row["iconState"].Value = 9;
            
            row = table.Create(Lot);
            row["iconID"].Value = 3;
            row["iconState"].Value = 10;
            
            row = table.Create(Lot);
            row["iconID"].Value = 164;
            row["iconState"].Value = 12;
        }

        private void BuildRender(Column row)
        {
            row["animationGroupIDs"].Value = "0,2010";
        }
    }
}