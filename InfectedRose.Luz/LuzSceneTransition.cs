using System;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    [Serializable]
    public class LuzSceneTransition : IConstruct
    {
        public string SceneTransitionName { get; set; }
        
        public float UnknownFloat { get; set; }
        
        public LuzSceneTransitionPoint[] TransitionPoints { get; set; }
        
        public uint Version { get; set; }
        
        public LuzSceneTransition(uint version)
        {
            Version = version;
        }

        public void Serialize(BitWriter writer)
        {
            if (Version < 0x28)
            {
                writer.WriteNiString(SceneTransitionName, false, true);

                writer.Write(UnknownFloat);
            }
            
            var pointCount = Version < 0x27 ? 5 : 2;

            var luzSceneTransitionPoints = TransitionPoints;
            
            if (luzSceneTransitionPoints.Length != pointCount)
            {
                Array.Resize(ref luzSceneTransitionPoints, pointCount);
            }

            for (var index = 0; index < pointCount; index++)
            {
                var transitionPoint = luzSceneTransitionPoints[index];

                if (transitionPoint == default)
                {
                    transitionPoint = new LuzSceneTransitionPoint();

                    luzSceneTransitionPoints[index] = transitionPoint;
                }
                
                transitionPoint.Serialize(writer);
            }

            TransitionPoints = luzSceneTransitionPoints;
        }

        public void Deserialize(BitReader reader)
        {
            if (Version < 0x28)
            {
                SceneTransitionName = reader.ReadNiString(false, true);

                UnknownFloat = reader.Read<float>();
            }

            var pointCount = Version < 0x27 ? 5 : 2;

            TransitionPoints = new LuzSceneTransitionPoint[pointCount];

            for (var i = 0; i < pointCount; i++)
            {
                TransitionPoints[i] = new LuzSceneTransitionPoint();
                TransitionPoints[i].Deserialize(reader);
            }
        }
    }
}