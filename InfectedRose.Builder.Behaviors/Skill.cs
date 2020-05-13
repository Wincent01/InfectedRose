using System;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;

namespace InfectedRose.Builder.Behaviors
{
    public class Skill
    {
        public uint Id { get; set; }

        public uint Cost { get; set; }
        
        public float Cooldown { get; set; }
        
        public uint CooldownGroup { get; set; }
        
        public uint Icon { get; set; }
        
        public BehaviorBase Root { get; set; }
        
        public static Skill Load(AccessDatabase database, uint id)
        {
            var table = database["SkillBehavior"];

            if (!table.Seek((int) id, out var skill))
            {
                throw new Exception($"Failed to find SkillBehavior for Skill Id: {id}!");
            }

            var entry = new SkillBehaviorTable(skill);
            
            return new Skill
            {
                Id = id,
                Cost = (uint) entry.imaginationcost,
                Cooldown = entry.cooldown,
                CooldownGroup = (uint) entry.cooldowngroup,
                Icon = (uint) entry.skillIcon,
                Root = BehaviorBase.Load(database, (uint) entry.behaviorID)
            };
        }

        public static Skill Create(AccessDatabase database)
        {
            var table = database["SkillBehavior"];

            var skill = table.Create();
            
            return new Skill
            {
                Id = (uint) skill.Key
            };
        }

        public void Apply(AccessDatabase database)
        {
            var table = database["SkillBehavior"];

            if (!table.Seek((int) Id, out var skill))
            {
                throw new Exception($"Failed to find SkillBehavior for Skill Id: {Id}!");
            }

            var entry = new SkillBehaviorTable(skill);

            entry.imaginationcost = (int) Cost;

            entry.cooldown = Cooldown;

            entry.cooldowngroup = (int) CooldownGroup;

            entry.skillIcon = (int) Icon;

            Root?.Apply(database);

            entry.behaviorID = (int) (Root?.Id ?? 0);
        }
    }
}