using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    public class DatabaseFile : IDeserializable
    {
        public List<object> Structure { get; set; }

        internal FdbTableHeader TableHeader { get; set; }
        
        public void Deserialize(BitReader reader)
        {
            var tableCount = reader.Read<uint>();

            using (new DatabaseScope(reader))
            {
                TableHeader = new FdbTableHeader(tableCount);

                TableHeader.Deserialize(reader);
            }
        }
        
        /// <summary>
        ///     Compile the database to a hash-map
        /// </summary>
        /// <remarks>
        ///     This is a really long process and should be run in a Task.
        /// </remarks>
        /// <returns>Compiled database</returns>
        public byte[] Compile(Action<int> onData)
        {
            Structure = new List<object>
            {
                (uint) TableHeader.Tables.Length,
                TableHeader
            };
            
            TableHeader.Compile(this);
            
            var fdb = new List<byte>();
            var pointers = new List<(DatabaseData, int)>();

            int index = default;
            foreach (var obj in Structure)
            {
                onData(++index);
                
                switch (obj)
                {
                    case null:
                        fdb.AddRange(ToBytes(-1));
                        break;
                    case DatabaseData data:
                    {
                        var pointer = pointers.Where(p => p.Item1 == data).ToArray();
                        if (pointer.Any())
                        {
                            var bytes = ToBytes(fdb.Count);

                            foreach (var tuple in pointer)
                            {
                                pointers.Remove(tuple);
                                for (var j = 0; j < 4; j++) fdb[tuple.Item2 + j] = bytes[j];
                            }
                        }
                        else
                        {
                            // Save pointers for last
                            pointers.Add((data, fdb.Count));

                            // Reserve space for pointer
                            fdb.AddRange(new byte[4]);
                        }

                        break;
                    }
                    default:
                        fdb.AddRange(ToBytes(obj));
                        break;
                }
            }

            return fdb.ToArray();
        }

        private static byte[] ToBytes(object obj)
        {
            if (!obj.GetType().IsValueType)
            {
                Console.WriteLine($"{obj} is not a valid struct");

                return new byte[0];
            }
            
            var size = Marshal.SizeOf(obj);
            var buf = new byte[size];
            var ptr = Marshal.AllocHGlobal(size);

            Marshal.StructureToPtr(obj, ptr, false);
            Marshal.Copy(ptr, buf, 0, size);

            return buf;
        }
    }
}