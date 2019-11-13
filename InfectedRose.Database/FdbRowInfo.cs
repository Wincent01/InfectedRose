using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowInfo : DatabaseData
    {
        public FdbRowDataHeader DataHeader { get; set; }

        public FdbRowInfo Linked { get; set; }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);
            databaseFile.Structure.Add(DataHeader);
            
            if (Linked == default)
                databaseFile.Structure.Add(-1);
            else
                databaseFile.Structure.Add(Linked);

            DataHeader?.Compile(databaseFile);
            Linked?.Compile(databaseFile);
        }

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
    }
}