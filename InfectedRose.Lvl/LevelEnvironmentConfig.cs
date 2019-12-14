using RakDotNet.IO;

namespace InfectedRose.Lvl
{
    public class LevelEnvironmentConfig : ChunkBase
    {
        public ParticleStruct[] ParticleStructs { get; set; }

        public override uint ChunkType => 2002;

        public override void Serialize(BitWriter writer)
        {
            writer.Write((uint) ParticleStructs.Length);

            foreach (var particleStruct in ParticleStructs)
            {
                particleStruct.Serialize(writer);
            }
        }

        public override void Deserialize(BitReader reader)
        {
            ParticleStructs = new ParticleStruct[reader.Read<uint>()];

            for (var i = 0; i < ParticleStructs.Length; i++)
            {
                var particle = new ParticleStruct();
                particle.Deserialize(reader);

                ParticleStructs[i] = particle;
            }
        }
    }
}