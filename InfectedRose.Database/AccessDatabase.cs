using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfectedRose.Database.Generic;

namespace InfectedRose.Database
{
    public class AccessDatabase : IList<Table>
    {
        public DatabaseFile File { get; private set; }

        public AccessDatabase(DatabaseFile file)
        {
            File = file;
        }
        
        public IEnumerator<Table> GetEnumerator()
        {
            return File.TableHeader.Tables.Select(t => new Table(t.info, t.data)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Table item)
        {
            if (item == default) return;
            
            var list = File.TableHeader.Tables.ToList();
            list.Add((item.Info, item.Data));
            File.TableHeader.Tables = list.ToArray();
        }

        public void Clear()
        {
            File.TableHeader.Tables = new (FdbColumnHeader info, FdbRowBucket data)[0];
        }

        public bool Contains(Table item)
        {
            return this.Any(value => value == item);
        }

        public void CopyTo(Table[] array, int arrayIndex)
        {
            var list = File.TableHeader.Tables.Select(t => new Table(t.info, t.data)).ToList();
            list.CopyTo(array, arrayIndex);
        }

        public bool Remove(Table item)
        {
            if (item == default) return false;

            var removal = File.TableHeader.Tables.FirstOrDefault(t => t.info == item.Info && t.data == item.Data);

            if (removal == default) return false;
            
            var list = File.TableHeader.Tables.ToList();
            list.Remove(removal);
            File.TableHeader.Tables = list.ToArray();

            return true;
        }

        public int Count => File.TableHeader.Tables.Length;

        public bool IsReadOnly => false;
        
        public int IndexOf(Table item)
        {
            if (item == default) return -1;
            
            return File.TableHeader.Tables.ToList().IndexOf(
                File.TableHeader.Tables.First(t => t.info == item.Info && t.data == item.Data)
            );
        }

        public void Insert(int index, Table item)
        {
            if (item == default) return;
            
            var list = File.TableHeader.Tables.ToList();
            list.Insert(index, (item.Info, item.Data));
            File.TableHeader.Tables = list.ToArray();
        }

        public void RemoveAt(int index)
        {
            var list = File.TableHeader.Tables.ToList();
            list.RemoveAt(index);
            File.TableHeader.Tables = list.ToArray();
        }

        public Table this[int index]
        {
            get
            {
                var (info, data) = File.TableHeader.Tables[index];

                return new Table(info, data);
            }
            set => File.TableHeader.Tables[index] = (value.Info, value.Data);
        }

        public Table this[string name]
        {
            get
            {
                foreach (var (info, data) in File.TableHeader.Tables)
                {
                    if (info.TableName == name)
                        return new Table(info, data);
                }

                return default;
            }
        }
    }
}