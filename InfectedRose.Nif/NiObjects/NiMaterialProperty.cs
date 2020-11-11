using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes the material shading properties.
	///         
	/// </summary>
	public class NiMaterialProperty : NiProperty
	{
		/// <summary>
		/// How much the material reflects ambient light.
		/// </summary>
		public Color3 AmbientColor { get; set; } 
		
		/// <summary>
		/// How much the material reflects diffuse light.
		/// </summary>
		public Color3 DiffuseColor { get; set; } 
		
		/// <summary>
		/// How much light the material reflects in a specular manner.
		/// </summary>
		public Color3 SpecularColor { get; set; } 
		
		/// <summary>
		/// How much light the material emits.
		/// </summary>
		public Color3 EmissiveColor { get; set; } 
		
		/// <summary>
		/// The material's glossiness.
		/// </summary>
		public float Glossiness { get; set; } 
		
		/// <summary>
		/// The material transparency (1=non-transparant). Refer to a NiAlphaProperty object in this material's parent NiTriShape object, when alpha is not 1.
		/// </summary>
		public float Alpha { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float EmitMulti { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			AmbientColor = new Color3();
			AmbientColor.Deserialize(reader);
			
			DiffuseColor = new Color3();
			DiffuseColor.Deserialize(reader);
			
			SpecularColor = new Color3();
			SpecularColor.Deserialize(reader);
			
			EmissiveColor = new Color3();
			EmissiveColor.Deserialize(reader);
			
			Glossiness = reader.Read<float>();
			
			Alpha = reader.Read<float>();
			
			EmitMulti = reader.Read<float>();
			
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
			
			writer.Write(EmitMulti);
			
		}
	}
	

}
