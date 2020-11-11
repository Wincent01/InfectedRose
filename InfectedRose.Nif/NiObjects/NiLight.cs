using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Light source.
	///         
	/// </summary>
	public abstract class NiLight : NiDynamicEffect
	{
		/// <summary>
		/// Dimmer.
		/// </summary>
		public float Dimmer { get; set; } 
		
		/// <summary>
		/// Ambient color.
		/// </summary>
		public Color3 AmbientColor { get; set; } 
		
		/// <summary>
		/// Diffuse color.
		/// </summary>
		public Color3 DiffuseColor { get; set; } 
		
		/// <summary>
		/// Specular color.
		/// </summary>
		public Color3 SpecularColor { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Dimmer = reader.Read<float>();
			
			AmbientColor = new Color3();
			AmbientColor.Deserialize(reader);
			
			DiffuseColor = new Color3();
			DiffuseColor.Deserialize(reader);
			
			SpecularColor = new Color3();
			SpecularColor.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Dimmer);
			
			writer.Write(AmbientColor);
			
			writer.Write(DiffuseColor);
			
			writer.Write(SpecularColor);
			
		}
	}
	

}
