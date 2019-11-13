using System;
using System.IO;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    [Serializable]
    public class LuzSceneTransition : IConstruct
    {
        public string SceneTransitionName { get; set; }
        
        public LuzSceneTransitionPoint[] TransitionPoints { get; set; }
        
        public uint Version { get; set; }
        
        public LuzSceneTransition(uint version)
        {
            Version = version;
        }

        public void Serialize(BitWriter writer)
        {
            if (Version < 0x25)
            {
                writer.WriteNiString(SceneTransitionName, false, true);
            }

            foreach (var transitionPoint in TransitionPoints)
            {
                transitionPoint.Serialize(writer);
            }
        }

        public void Deserialize(BitReader reader)
        {
            if (Version < 0x25)
            {
                SceneTransitionName = reader.ReadNiString(false, true);
            }

            var pointCount = Version <= 21 || Version >= 0x27 ? 2 : 5;
            
            TransitionPoints = new LuzSceneTransitionPoint[pointCount];

            for (var i = 0; i < pointCount; i++)
            {
                TransitionPoints[i] = new LuzSceneTransitionPoint();
                TransitionPoints[i].Deserialize(reader);
            }
        }
    }
}