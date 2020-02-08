using RakDotNet.IO;

namespace InfectedRose.Nif
{
    public class NiMaterialProperty : NiProperty
    {
        public Color3 AmbientColor { get; set; }
        
        public Color3 DiffuseColor { get; set; }
        
        public Color3 SpecularColor { get; set; }
        
        public Color3 EmissiveColor { get; set; }
        
        public float Glossiness { get; set; }
        
        public float Alpha { get; set; }
        
        public float EmitMultiplier { get; set; }
        
        public override void Deserialize(BitReader reader)
        {
            base.Deserialize(reader);
            
            AmbientColor = reader.Read<Color3>();

            DiffuseColor = reader.Read<Color3>();

            SpecularColor = reader.Read<Color3>();

            EmissiveColor = reader.Read<Color3>();

            Glossiness = reader.Read<float>();

            Alpha = reader.Read<float>();

            EmitMultiplier = reader.Read<float>();
        }

        public override void Serialize(BitWriter writer)
        {
            base.Serialize(writer);
            
            writer.Write(AmbientColor);

            writer.Write(DiffuseColor);

            writer.Write(SpecularColor);

            writer.Write(EmissiveColor);

            writer.Write(Glossiness);

            writer.Write(Alpha);

            writer.Write(EmitMultiplier);
        }
    }
}