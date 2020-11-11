using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This particle system modifier controls the particle size. If it is present the particles start with size 0.0 . Then they grow to their original size and stay there until they fade to zero size again at the end of their lifetime cycle.
	///         
	/// </summary>
	public class NiParticleGrowFade : NiParticleModifier
	{
		/// <summary>
		/// The time from the beginning of the particle lifetime during which the particle grows.
		/// </summary>
		public float Grow { get; set; } 
		
		/// <summary>
		/// The time from the end of the particle lifetime during which the particle fades.
		/// </summary>
		public float Fade { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Grow = reader.Read<float>();
			
			Fade = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Grow);
			
			writer.Write(Fade);
			
		}
	}
	

}
