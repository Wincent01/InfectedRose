using System;
using System.Linq;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbRowData : DatabaseData
    {
        public FdbRowData(uint columnCount)
        {
            Fields = new (DataType, object)[columnCount];
        }

        public (DataType type, object value)[] Fields { get; set; }

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

        public override void Compile(HashMap map)
        {
            map += this;

            for (var i = 0; i < Fields.Length; i++)
            {
                map += (uint) Fields[i].type;

                switch (Fields[i].type)
                {
                    case DataType.Boolean:
                        var b = (bool) Fields[i].value;
                        map += b ? 1 : 0;
                        break;
                    case DataType.Nothing:
                        map += 0;
                        break;
                    default:
                        map += Fields[i].value;
                        break;
                }
            }

            foreach (var o in Fields.Where(f => f.type != DataType.Nothing))
                if (o.value is DatabaseData data)
                    data.Compile(map);
        }
    }
}