using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfectedRose.Database.Fdb;

namespace InfectedRose.Database.Generic
{
    public class TypedTable<T> : Table where T : class
    {
        private readonly Dictionary<T, int> _managed;

        internal TypedTable(FdbColumnHeader info, FdbRowBucket data, AccessDatabase database) : base(info, data,
            database)
        {
            _managed = new Dictionary<T, int>();
        }

        public new T this[int index]
        {
            get
            {
                if (_managed.ContainsValue(index)) return _managed.First(m => m.Value == index).Key;

                var type = typeof(T);

                var instance = (T) Activator.CreateInstance(type, true);

                var baseColumn = base[index];

                foreach (var property in type.GetProperties())
                {
                    var attribute = property.GetCustomAttribute<ColumnAttribute>();

                    var id = attribute?.Name ?? property.Name;

                    var data = baseColumn[id].Value;

                    property.SetValue(instance, data);
                }

                _managed[instance] = index;

                return instance;
            }
        }

        public void Save()
        {
            var type = typeof(T);

            var properties = type.GetProperties();

            foreach (var pair in _managed)
            {
                var index = pair.Value;
                var column = pair.Key;
                
                var baseColumn = base[index];

                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttribute<ColumnAttribute>();

                    var id = attribute?.Name ?? property.Name;

                    var value = property.GetValue(column);

                    var data = value switch
                    {
                        long lon => new FdbBitInt {Value = lon},
                        string str => new FdbString {Value = str},
                        _ => value
                    };

                    baseColumn[id].Value = data;
                }
            }
        }
    }
}