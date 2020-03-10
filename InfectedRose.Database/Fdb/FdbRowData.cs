using System;
using System.Collections.Generic;
using System.Linq;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbRowData : IConstruct
    {
        public FdbRowData(uint columnCount)
        {
            Fields = new (DataType, object)[columnCount];
        }

        public (DataType type, object value)[] Fields { get; set; }

        public void Deserialize(BitReader reader)
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

        public void Serialize(BitWriter writer)
        {
            var pointer = new List<(ISerializable, PointerToken)>();
            
            foreach (var (type, value) in Fields)
            {
                writer.Write((uint) type);
                
                switch (type)
                {
                    case DataType.Boolean:
                        var b = (bool) value;
                        writer.Write(b ? 1 : 0);
                        break;
                    case DataType.Nothing:
                        writer.Write(0);
                        break;
                    case DataType.Integer:
                        writer.Write(Convert.ToInt32(value));
                        break;
                    case DataType.Unknown1:
                        writer.Write(Convert.ToInt32(value));
                        break;
                    case DataType.Float:
                        writer.Write(Convert.ToSingle(value));
                        break;
                    case DataType.Text:
                        if (value == null)
                        {
                            writer.Write(-1);
                        }
                        else
                        {
                            pointer.Add(((ISerializable) value, new PointerToken(writer)));
                        }
                        break;
                    case DataType.Bigint:
                        if (value == null)
                        {
                            writer.Write(-1);
                        }
                        else
                        {
                            pointer.Add(((ISerializable) value, new PointerToken(writer)));
                        }
                        break;
                    case DataType.Unknown2:
                        writer.Write(Convert.ToInt32(value));
                        break;
                    case DataType.Varchar:
                        if (value == null)
                        {
                            writer.Write(-1);
                        }
                        else
                        {
                            pointer.Add(((ISerializable) value, new PointerToken(writer)));
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(type.ToString());
                }
            }

            foreach (var (deserializable, token) in pointer)
            {
                token.Dispose();

                deserializable.Serialize(writer);
            }
        }
    }
}