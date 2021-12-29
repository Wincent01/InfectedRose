using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace InfectedRose.Core
{
    public class HashMap
    {
        protected List<object> Structure { get; set; }

        public void Add(object obj)
        {
            Structure.Add(obj);
        }

        public virtual byte[] Compile(Action<int> onData = default)
        {
            var compiled = new List<byte>();
            var pointers = new List<(HashConstruct, int)>();

            int index = default;
            foreach (var obj in Structure)
            {
                onData?.Invoke(++index);

                switch (obj)
                {
                    case null:
                        compiled.AddRange(ToBytes(-1));
                        break;
                    case HashConstruct data:
                    {
                        var pointer = pointers.FirstOrDefault(p => p.Item1 == data);
                        if (pointer != default)
                        {
                            var bytes = ToBytes(compiled.Count);

                            pointers.Remove(pointer);
                            for (var j = 0; j < 4; j++) compiled[pointer.Item2 + j] = bytes[j];
                        }
                        else
                        {
                            // Save pointers for last
                            pointers.Add((data, compiled.Count));

                            // Reserve space for pointer
                            compiled.AddRange(new byte[4]);
                        }

                        break;
                    }
                    default:
                        compiled.AddRange(ToBytes(obj));
                        break;
                }
            }

            return compiled.ToArray();
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
            Marshal.FreeHGlobal(ptr);

            return buf;
        }

        public static HashMap operator +(HashMap map, object obj)
        {
            map.Add(obj);

            return map;
        }
    }
}
