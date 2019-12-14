using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Database
{
    public class DatabaseFile : HashMap, IDeserializable
    {
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
        public override byte[] Compile(Action<int> onData = default)
        {
            Structure = new List<object>
            {
                (uint) TableHeader.Tables.Length,
                TableHeader
            };
            
            TableHeader.Compile(this);

            return base.Compile(onData);
        }
    }
}