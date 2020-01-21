using System.Threading.Tasks;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowInfo : DatabaseData
    {
        public FdbRowDataHeader DataHeader { get; set; }

        public FdbRowInfo Linked { get; set; }

        public override void Deserialize(BitReader reader)
        {
            using (var s = new DatabaseScope(reader, true))
            {
                if (s)
                {
                    DataHeader = new FdbRowDataHeader();

                    DataHeader.Deserialize(reader);
                }
            }

            using (var s = new DatabaseScope(reader, true))
            {
                if (!s) return;

                Linked = new FdbRowInfo();

                Linked.Deserialize(reader);
            }
        }

        public override void Compile(HashMap map)
        {
            // Super hacky way of getting around stackoverflow
            Task.Run(() =>
            {
                lock (map)
                {
                    map += this;
                    map += DataHeader;

                    if (Linked == default)
                        map += -1;
                    else
                        map += Linked;

                    DataHeader?.Compile(map);
                }

                Linked?.Compile(map);
            }).Wait();
        }
    }
}