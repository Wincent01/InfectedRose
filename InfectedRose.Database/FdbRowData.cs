using System;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    internal class FdbRowData : DatabaseData
    {
        public FdbRowData(uint columnCount)
        {
            Fields = new (DataType, object)[columnCount];
        }
        
        public (DataType type, object value)[] Fields { get; set; }

        internal override void Compile(DatabaseFile databaseFile)
        {
            databaseFile.Structure.Add(this);

            for (var i = 0; i < Fields.Length; i++)
            {
                databaseFile.Structure.Add((uint) Fields[i].type);
                databaseFile.Structure.Add(Fields[i].value);
            }

            foreach (var o in Fields)
                if (o.value is DatabaseData data)
                    data.Compile(databaseFile);
        }

        public override void Deserialize(BitReader reader)
        {
            for (var i = 0; i < Fields.Length; i++)
            {
                Fields[i].type = (DataType) reader.Read<uint>();

                switch (Fields[i].type)
                {
                    case DataType.Nothing:
                        Fields[i].value = reader.Read<int>();
                        break;
                    case DataType.Integer:
                        Fields[i].value = reader.Read<int>();
                        break;
                    case DataType.Unknown1:
                        Fields[i].value = reader.Read<int>();
                        break;
                    case DataType.Float:
                        Fields[i].value = reader.Read<float>();
                        break;
                    case DataType.Text:
                        var str = new FdbString();
                        str.Deserialize(reader);

                        Fields[i].value = str;
                        break;
                    case DataType.Boolean:
                        Fields[i].value = reader.Read<int>() != 0;
                        break;
                    case DataType.Bigint:
                        var bigInt = new FdbBitInt();
                        bigInt.Deserialize(reader);

                        Fields[i].value = bigInt;
                        break;
                    case DataType.Unknown2:
                        Fields[i].value = reader.Read<int>();
                        break;
                    case DataType.Varchar:
                        var str1 = new FdbString();
                        str1.Deserialize(reader);

                        Fields[i].value = str1;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}