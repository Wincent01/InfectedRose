using System;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbRowInfo : DatabaseData
    {
        public FdbRowDataHeader DataHeader { get; set; }

        public FdbRowInfo Linked { get; set; }

        public override void Deserialize(BitReader reader)
        {
            throw new InvalidOperationException("This database data can only be deserialized with a header.");
        }

        public override void Compile(HashMap map)
        {
            throw new InvalidOperationException("This database data can only be complied with a header.");
        }
    }
}