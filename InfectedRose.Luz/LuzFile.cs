using System;
using System.Numerics;
using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Luz
{
    public class LuzFile : IConstruct
    {
        public uint Version { get; set; }
        
        public uint RevisionNumber { get; set; }
    
        public uint WorldId { get; set; }
    
        public Vector3 SpawnPoint { get; set; }
        
        public Quaternion SpawnRotation { get; set; }

        public LuzScene[] Scenes { get; set; }
        
        public byte UnknownByte { get; set; }
        
        public string TerrainFileName { get; set; }
        
        public string TerrainFile { get; set; }
        
        public string TerrainDescription { get; set; }

        public LuzSceneTransition[] Transitions { get; set; } = new LuzSceneTransition[0];

        public uint PathFormatVersion { get; set; } = 18;

        public LuzPathData[] PathData { get; set; } = new LuzPathData[0];

        public void Serialize(BitWriter writer)
        {
            writer.Write(Version);

            if (Version >= 0x24)
            {
                writer.Write(RevisionNumber);
            }

            writer.Write(WorldId);

            if (Version >= 0x26)
            {
                writer.Write(SpawnPoint);
                writer.Write(SpawnRotation);
            }

            if (Version < 0x25)
            {
                writer.Write((byte) Scenes.Length);
            }
            else
            {
                writer.Write((uint) Scenes.Length);
            }

            foreach (var scene in Scenes)
            {
                scene.Serialize(writer);
            }

            writer.Write(UnknownByte);

            writer.WriteNiString(TerrainFileName, false, true);
            
            writer.WriteNiString(TerrainFile, false, true);
            
            writer.WriteNiString(TerrainDescription, false, true);

            if (Version >= 20)
            {
                writer.Write((uint) Transitions.Length);

                foreach (var transition in Transitions)
                {
                    transition.Serialize(writer);
                }
            }
            
            if (Version < 0x23) return;

            var position = writer.BaseStream.Position;

            WritePaths(writer);
            
            var finishPosition = writer.BaseStream.Position;
            
            writer.BaseStream.Position = position;
            
            writer.Write(finishPosition - position - 4);
        }

        private void WritePaths(BitWriter writer)
        {
            using var token = new LengthToken(writer);
            
            token.Allocate();

            writer.Write(PathFormatVersion);

            writer.Write((uint) (PathData?.Length ?? 0));

            if (PathData == default) return;
            
            foreach (var pathData in PathData)
            {
                writer.Write(pathData.Version);

                writer.WriteNiString(pathData.PathName, true, true);

                writer.Write((uint) pathData.Type);

                writer.Write(pathData.UnknownInt);

                pathData.Serialize(writer);

                writer.Write((uint) pathData.Waypoints.Length);

                foreach (var wayPoint in pathData.Waypoints)
                {
                    wayPoint.Serialize(writer);
                }
            }
        }

        public void Deserialize(BitReader reader)
        {
            Version = reader.Read<uint>();

            if (Version >= 0x24)
            {
                RevisionNumber = reader.Read<uint>();
            }

            WorldId = reader.Read<uint>();

            if (Version >= 0x26)
            {
                SpawnPoint = reader.Read<Vector3>();
                SpawnRotation = reader.Read<Quaternion>();
            }

            var sceneCount = Version < 0x25 ? reader.Read<byte>() : reader.Read<uint>();
            
            Scenes = new LuzScene[sceneCount];

            for (var i = 0; i < sceneCount; i++)
            {
                Scenes[i] = new LuzScene();
                Scenes[i].Deserialize(reader);
            }

            UnknownByte = reader.Read<byte>();

            TerrainFileName = reader.ReadNiString(false, true);

            TerrainFile = reader.ReadNiString(false, true);

            TerrainDescription = reader.ReadNiString(false, true);

            if (Version >= 0x20)
            {
                var sceneTransitionCount = reader.Read<uint>();
                
                Transitions = new LuzSceneTransition[sceneTransitionCount];

                for (var i = 0; i < sceneTransitionCount; i++)
                {
                    Transitions[i] = new LuzSceneTransition(Version);
                    Transitions[i].Deserialize(reader);
                }
            }

            if (Version < 0x23) return;
            {
                reader.Read<uint>();
                PathFormatVersion = reader.Read<uint>();
                
                var pathDataCount = reader.Read<uint>();
                
                PathData = new LuzPathData[pathDataCount];

                for (var i = 0; i < pathDataCount; i++)
                {
                    var version = reader.Read<uint>();
                    var name = reader.ReadNiString(true, true);
                    var type = (PathType) reader.Read<uint>();

                    PathData[i] = type switch
                    {
                        PathType.Movement => new LuzPathData(version),
                        PathType.MovingPlatform => new LuzMovingPlatformPath(version),
                        PathType.Property => new LuzPropertyPath(version),
                        PathType.Camera => new LuzCameraPath(version),
                        PathType.Spawner => new LuzSpawnerPath(version),
                        PathType.Showcase => new LuzPathData(version),
                        PathType.Race => new LuzPathData(version),
                        PathType.Rail => new LuzPathData(version),
                        _ => throw new ArgumentOutOfRangeException()
                    };

                    PathData[i].UnknownInt = reader.Read<uint>();

                    PathData[i].PathName = name;
                    PathData[i].Type = type;
                    PathData[i].Deserialize(reader);

                    var count = reader.Read<uint>();
                    PathData[i].Waypoints = new LuzPathWaypoint[count];

                    for (var j = 0; j < count; j++)
                    {
                        PathData[i].Waypoints[j] = type switch
                        {
                            PathType.Movement => new LuzMovementWaypoint(version),
                            PathType.MovingPlatform => new LuzMovingPlatformWaypoint(version),
                            PathType.Property => new LuzPathWaypoint(version),
                            PathType.Camera => new LuzCameraWaypoint(version),
                            PathType.Spawner => new LuzSpawnerWaypoint(version),
                            PathType.Showcase => new LuzPathWaypoint(version),
                            PathType.Race => new LuzRaceWaypoint(version),
                            PathType.Rail => new LuzRailWaypoint(version),
                            _ => throw new ArgumentOutOfRangeException()
                        };

                        PathData[i].Waypoints[j].Deserialize(reader);
                    }
                }
            }
        }
    }
}