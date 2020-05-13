using System;
using System.Collections.Generic;
using System.Reflection;
using InfectedRose.Builder.Behaviors.External;
using InfectedRose.Database;
using InfectedRose.Database.Concepts.Tables;

namespace InfectedRose.Builder.Behaviors
{
    public abstract class BehaviorBase
    {
        public static Dictionary<uint, BehaviorBase> Cache { get; }
        
        public uint Id { get; set; }
        
        public uint Effect { get; set; }
        
        public List<BehaviorBase> Branches { get; set; }

        public BehaviorBase()
        {
            Branches = new List<BehaviorBase>();
        }

        static BehaviorBase()
        {
            Cache = new Dictionary<uint, BehaviorBase>();
        }

        public static BehaviorBase Load(AccessDatabase database, uint id)
        {
            return Load(database, id, out _);
        }
        
        public static BehaviorBase Load(AccessDatabase database, uint id, out bool cached)
        {
            lock (Cache)
            {
                cached = Cache.TryGetValue(id, out var cache);
                
                if (cached)
                {
                    return cache;
                }
            }
            
            var table = database["BehaviorTemplate"];

            if (!table.Seek((int) id, out var behavior))
            {
                throw new Exception($"Failed to find BehaviorTemplate for Behavior Id: {id}!");
            }

            var entry = new BehaviorTemplateTable(behavior);

            var template = (Template) entry.templateID;

            var instance = BehaviorRegistry.InquireBehavior(template);
            
            lock (Cache)
            {
                Cache[id] = instance;
            }
            
            instance.Id = id;

            instance.Effect = (uint) entry.effectID;

            instance.Load(database);

            foreach (var property in instance.GetType().GetProperties())
            {
                var attribute = property.GetCustomAttribute<ParameterAttribute>();
                
                if (attribute == null) continue;

                object value;
                
                if (property.PropertyType == typeof(BehaviorBase))
                {
                    value = instance.Branch(database, attribute.Name);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    value = instance.GetParameter<int>(database, attribute.Name) == 1;
                }
                else
                {
                    value = instance.GetParameter(database, attribute.Name, property.PropertyType);
                    
                    if (value == null) continue;
                }

                property.SetValue(instance, value);
            }

            return instance;
        }

        protected virtual void Load(AccessDatabase database)
        {
        }

        public void Apply(AccessDatabase database)
        {
            foreach (var property in GetType().GetProperties())
            {
                if (property.PropertyType != typeof(BehaviorBase)) continue;
                
                var behavior = (BehaviorBase) property.GetValue(this);

                if (behavior == null) continue;
                
                if (!Branches.Contains(behavior))
                {
                    Branches.Add(behavior);
                }
            }

            if (Id == default)
            {
                var table = database["BehaviorTemplate"];

                var entry = table.Create();

                var template = new BehaviorTemplateTable(entry);

                Id = (uint) template.behaviorID;

                template.effectID = (int) Effect;

                var type = GetType();

                var attribute = type.GetCustomAttribute<BehaviorAttribute>();

                if (attribute == null)
                {
                    throw new Exception($"Invalid behavior template: {type}!");
                }
                
                template.templateID = (int) attribute.Template;
            }
            
            foreach (var branch in Branches)
            {
                branch.Apply(database);
            }
            
            foreach (var property in GetType().GetProperties())
            {
                var attribute = property.GetCustomAttribute<ParameterAttribute>();

                if (attribute == null) continue;
                
                if (property.PropertyType == typeof(BehaviorBase))
                {
                    var behavior = (BehaviorBase) property.GetValue(this);

                    SetParameter(database, attribute.Name, behavior);
                }
                else if (property.PropertyType == typeof(bool))
                {
                    var boolean = (bool) property.GetValue(this);

                    SetParameter(database, attribute.Name, boolean ? 1 : 0);
                }
                else
                {
                    SetParameter(database, attribute.Name, (object) property.GetValue(this));
                }
            }

            ApplyChanges(database);
        }

        protected virtual void ApplyChanges(AccessDatabase database)
        {
        }

        public virtual void Export(BehaviorXml details)
        {
        }

        public T GetParameter<T>(AccessDatabase database, string name) where T : struct
        {
            var table = database["BehaviorParameter"];

            foreach (var column in table.SeekMultiple((int) Id))
            {
                var entry = new BehaviorParameterTable(column);

                if (entry.parameterID == name)
                {
                    return (T) Convert.ChangeType(entry.value, typeof(T));
                }
            }

            return default;
        }
        
        public object GetParameter(AccessDatabase database, string name, Type type)
        {
            var table = database["BehaviorParameter"];

            foreach (var column in table.SeekMultiple((int) Id))
            {
                var entry = new BehaviorParameterTable(column);

                if (entry.parameterID == name)
                {
                    return Convert.ChangeType(entry.value, type);
                }
            }

            return default;
        }

        public IEnumerable<string> GetParameterKeys(AccessDatabase database)
        {
            var table = database["BehaviorParameter"];

            foreach (var column in table.SeekMultiple((int) Id))
            {
                var entry = new BehaviorParameterTable(column);

                yield return entry.parameterID;
            }
        }

        public void SetParameter(AccessDatabase database, string name, object value)
        {
            var table = database["BehaviorParameter"];

            var single = (float) Convert.ChangeType(value, typeof(float));

            BehaviorParameterTable entry;
            
            foreach (var column in table.SeekMultiple((int) Id))
            {
                entry = new BehaviorParameterTable(column);

                if (entry.parameterID != name) continue;
                
                entry.value = single;
                    
                return;
            }

            entry = new BehaviorParameterTable(table.Create((int) Id));

            entry.value = single;

            entry.parameterID = name;
        }

        public void SetParameter(AccessDatabase database, string name, BehaviorBase value)
        {
            SetParameter(database, name, value?.Id ?? 0);
        }

        public BehaviorBase Branch(AccessDatabase database, string parameter)
        {
            var id = GetParameter<uint>(database, parameter);

            return Branch(database, id);
        }
        
        public BehaviorBase Branch(AccessDatabase database, uint id)
        {
            if (id == default) return null;
            
            var behavior = Load(database, id, out var cached);

            if (!cached)
            {
                Branches.Add(behavior);
            }

            return behavior;
        }
    }
}