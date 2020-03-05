using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace InfectedRose.Database.Concepts
{
    public class LwoObject : IList<LwoComponent>
    {
        internal LwoObject(Column row)
        {
            Database = row.Table.Database;

            Row = row;
        }

        public AccessDatabase Database { get; }

        public Column Row { get; }

        private List<LwoComponent> Components
        {
            get
            {
                var components = new List<LwoComponent>();

                foreach (var entry in Database["ComponentsRegistry"].Where(r => r.Key == Row.Key))
                {
                    var type = (ComponentId) entry["component_type"].Value;

                    var component = new LwoComponent
                    {
                        Database = Database,
                        Entry = entry,
                        Id = type
                    };

                    components.Add(component);

                    var componentTable = Database[$"{type}"];

                    var id = (int) entry["component_id"].Value;

                    if (id == 0 || componentTable == default) continue;

                    component.Row = componentTable.FirstOrDefault(r => r.Key == id);
                }

                return components;
            }
        }

        public IEnumerator<LwoComponent> GetEnumerator()
        {
            return Components.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(LwoComponent item)
        {
            if (item == default) return;

            if (Components.Any(c => c.Id == item.Id)) return;

            var entryTable = Database["ComponentsRegistry"];

            var entry = entryTable.Create(Row.Key);

            entry["component_type"].Value = (int) item.Id;

            item.Entry = entry;
            item.Database = Database;

            var componentTable = Database[$"{item.Id}"];

            if (componentTable == default)
            {
                entry["component_id"].Value = 0;

                return;
            }

            var component = componentTable.Create();
            
            Console.WriteLine($"Adding component [{Row.Key}]: {item.Id} -> {component.Key}");

            entry["component_id"].Value = component.Key;

            item.Row = component;
        }

        public void Clear()
        {
            var entryTable = Database["ComponentsRegistry"];

            foreach (var component in Components)
            {
                entryTable.Remove(component.Entry);

                component.Row?.Table.Remove(component.Row);
            }
        }

        public bool Contains(LwoComponent item)
        {
            return Components.Any(c => c.Id == item?.Id && c.Row.Key == item.Row?.Key);
        }

        public void CopyTo(LwoComponent[] array, int arrayIndex)
        {
            Components.CopyTo(array, arrayIndex);
        }

        public bool Remove(LwoComponent item)
        {
            if (!Contains(item) || item == default) return false;

            var entryTable = Database["ComponentsRegistry"];

            entryTable.Remove(item.Entry);

            item.Row?.Table.Remove(item.Row);

            return true;
        }

        public int Count => Components.Count;

        public bool IsReadOnly => false;

        public int IndexOf(LwoComponent item)
        {
            return Components.IndexOf(item);
        }

        public void Insert(int index, LwoComponent item)
        {
            throw new NotSupportedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotSupportedException();
        }

        public LwoComponent this[int index]
        {
            get => Components[index];
            set => throw new NotSupportedException();
        }
    }
}