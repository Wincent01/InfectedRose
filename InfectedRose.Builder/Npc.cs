using System.Collections.Generic;
using System.Linq;
using InfectedRose.Database;
using InfectedRose.Database.Concepts;

namespace InfectedRose.Builder
{
    public class Npc
    {
        internal AccessDatabase Database { get; }
        
        internal int Source { get; }
        
        public int Lot { get; }
        
        public string Name { get; set; }
        
        public int InteractDistance { get; set; }
        
        public CharacterStyle Style { get; set; } = new CharacterStyle();
        
        public List<int> Items { get; set; } = new List<int>();
        
        public List<MissionEntry> Missions { get; set; } = new List<MissionEntry>();

        public Npc(AccessDatabase database, int source = 12261)
        {
            Database = database;
            Source = source;

            var table = database["Objects"];

            Lot = table.ClaimKey(20000);
        }

        public int Build()
        {
            var concept = Database.CopyObject(Source, Lot);

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

            return concept.Row.Key;
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