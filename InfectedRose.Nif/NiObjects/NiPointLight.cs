using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A point light.
	///         
	/// </summary>
	public class NiPointLight : NiLight
	{
		/// <summary>
		/// Constant Attenuation
		/// </summary>
		public float ConstantAttenuation { get; set; } 
		
		/// <summary>
		/// Linear Attenuation
		/// </summary>
		public float LinearAttenuation { get; set; } 
		
		/// <summary>
		/// Quadratic Attenuation (see glLight)
		/// </summary>
		public float QuadraticAttenuation { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ConstantAttenuation = reader.Read<float>();
			
			LinearAttenuation = reader.Read<float>();
			
			QuadraticAttenuation = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ConstantAttenuation);
			
			writer.Write(LinearAttenuation);
			
			writer.Write(QuadraticAttenuation);
			
		}
	}
	

}
