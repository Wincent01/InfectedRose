using System;
using System.Collections.Generic;
using InfectedRose.Luz;
using InfectedRose.Lvl;

namespace InfectedRose.Utilities
{
    public static class LuzFileExtensions
    {
        public static uint GenerateChecksum(this LuzFile @this, List<LvlFile> scenes)
        {
            if (@this.Scenes.Length != scenes.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(scenes), "The count of scenes has to equal the count of scenes in this luz file.");
            }
            
            uint value = ushort.MaxValue; // For checksum calculations
            uint total = ushort.MaxValue; // Sum of all changes applied to value
            
            var zoneLayer = new ChecksumLayer
            {
                Id = uint.MaxValue,
                Layer = default,
                Revision = @this.RevisionNumber
            };

            zoneLayer.Apply(ref value, ref total);

            for (var index = 0; index < scenes.Count; index++)
            {
                var scene = scenes[index];
                var lvl = @this.Scenes[index];
                
                //
                // Get revision
                //

                var revision = scene.LevelInfo?.RevisionNumber ?? scene.OldLevelHeader.Revision;

                //
                // Get layer
                //

                var sceneLayer = new ChecksumLayer
                {
                    Id = lvl.SceneId,
                    Layer = lvl.LayerId,
                    Revision = revision
                };

                sceneLayer.Apply(ref value, ref total);
            }
            
            //
            // Get final checksum
            //
            
            var lower = (ushort) ((value & ushort.MaxValue) + (value >> 16));
            var upper = (ushort) ((total & ushort.MaxValue) + (total >> 16));

            //
            // The checksum has two parts, one for the 'total', and one for the 'value', these combine to form a 32bit value
            // 

            return (uint) (upper << 16 | lower);
        }
    }
}