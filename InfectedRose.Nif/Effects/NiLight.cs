using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiLight : NiDynamicEffect
    {
        public float Dimmer { get; set; }
        
        public Color3 Ambient { get; set; }
        
        public Color3 Diffuse { get; set; }
        
        public Color3 Specular { get; set; }

        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);

            Dimmer = reader.Read<float>();

            Ambient = reader.Read<Color3>();

            Diffuse = reader.Read<Color3>();

            Specular = reader.Read<Color3>();
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);

            writer.Write(Dimmer);

            writer.Write(Ambient);

            writer.Write(Diffuse);

            writer.Write(Specular);
        }
    }
}