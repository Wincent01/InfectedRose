using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A spot.
	///         
	/// </summary>
	public class NiSpotLight : NiPointLight
	{
		/// <summary>
		/// The opening angle of the spot.
		/// </summary>
		public float CutoffAngle { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat { get; set; } 
		
		/// <summary>
		/// Describes the distribution of light. (see: glLight)
		/// </summary>
		public float Exponent { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			CutoffAngle = reader.Read<float>();
			
			UnknownFloat = reader.Read<float>();
			
			Exponent = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(CutoffAngle);
			
			writer.Write(UnknownFloat);
			
			writer.Write(Exponent);
			
		}
	}
	

}
