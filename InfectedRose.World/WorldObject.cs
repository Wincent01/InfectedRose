using System;
using System.Numerics;
using System.Xml.Serialization;
using InfectedRose.Lvl;

namespace InfectedRose.World
{
    [XmlRoot("Object")]
    public class WorldObject
    {
        [XmlAttribute] public int Lot { get; set; }
        
        [XmlAttribute] public uint AssetType { get; set; }
        
        [XmlElement] public Vector3 Position { get; set; }
        
        [XmlElement] public Quaternion Rotation { get; set; }
        
        [XmlElement] public float Scale { get; set; }
        
        [XmlElement] public string Info { get; set; }

        public LevelObjectTemplate Template
        {
            get
            {
                var random = new Random();

                Console.WriteLine($"Creating world object: {Lot}");
                
                return new LevelObjectTemplate
                {
                    Lot = Lot,
                    AssetType = AssetType,
                    Position = Position,
                    Rotation = Rotation,
                    LegoInfo = LegoDataDictionary.FromString(Info),
                    Scale = Scale,
                    ObjectId = (ulong) random.Next(default, int.MaxValue) & ((ulong) random.Next(default, int.MaxValue) << 32)
                };
            }
        }
    }
}