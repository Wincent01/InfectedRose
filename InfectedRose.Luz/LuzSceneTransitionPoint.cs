using System;
using System.IO;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    [Serializable]
    public class LuzSceneTransitionPoint : IConstruct
    {
        public ulong SceneId { get; set; }
        
        public Vector3 Point { get; set; }

        public void Serialize(BitWriter writer)
        {
            writer.Write(SceneId);

            writer.Write(Point);
        }

        public void Deserialize(BitReader reader)
        {
            SceneId = reader.Read<ulong>();

            Point = reader.Read<Vector3>();
        }
    }
}