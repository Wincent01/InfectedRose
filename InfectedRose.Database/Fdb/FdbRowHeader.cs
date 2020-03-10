using System.Collections.Generic;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database.Fdb
{
    internal class FdbRowHeader : IConstruct
    {
        private readonly uint _rowCount;

        public FdbRowInfo[] RowInfos;

        public FdbRowHeader(uint rowCount)
        {
            _rowCount = rowCount;
        }

        public void Deserialize(BitReader reader)
        {
            RowInfos = new FdbRowInfo[_rowCount];

            for (var i = 0; i < _rowCount; i++)
            {
                using var s = new DatabaseScope(reader, true);

                if (!s) continue;

                var info = new FdbRowInfo();

                RowInfos[i] = info;

                while (info != default)
                {
                    using (var scope = new DatabaseScope(reader, true))
                    {
                        if (scope)
                        {
                            info.DataHeader = new FdbRowDataHeader();

                            info.DataHeader.Deserialize(reader);
                        }
                    }

                    {
                        var scope = new DatabaseScope(reader, true);
                        
                        if (!scope)
                        {
                            break;
                        }

                        info.Linked = new FdbRowInfo();

                        info = info.Linked;
                    }
                }
            }
        }

        public void Serialize(BitWriter writer)
        {
            var toSerialize = new List<(FdbRowInfo, PointerToken)>();

            foreach (var info in RowInfos)
            {
                if (info == default)
                {
                    writer.Write(-1);
                }
                else
                {
                    toSerialize.Add((info, new PointerToken(writer)));
                }
            }

            for (var i = 0; i < FdbRowBucket.NextPowerOf2(RowInfos.Length) - RowInfos.Length; i++)
            {
                writer.Write(-1);
            }
            
            foreach (var serialize in toSerialize)
            {
                var (info, pointer) = serialize;

                var current = info;

                while (current != default && pointer != default)
                {
                    pointer.Dispose();

                    PointerToken dataPointer = default;

                    if (current.DataHeader == default)
                    {
                        writer.Write(-1);
                    }
                    else
                    {
                        dataPointer = new PointerToken(writer);
                    }

                    if (current.Linked == default)
                    {
                        writer.Write(-1);

                        pointer = default;
                    }
                    else
                    {
                        pointer = new PointerToken(writer);
                    }

                    if (dataPointer != default)
                    {
                        dataPointer.Dispose();

                        current.DataHeader.Serialize(writer);
                    }

                    current = current.Linked;
                }
            }
        }
    }
}