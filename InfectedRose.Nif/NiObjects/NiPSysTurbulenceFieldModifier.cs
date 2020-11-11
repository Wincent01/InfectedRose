using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system modifier, used for controlling the particle velocity in drag space warp.
	///         
	/// </summary>
	public class NiPSysTurbulenceFieldModifier : NiPSysFieldModifier
	{
		/// <summary>
		/// Frequency of the update.
		/// </summary>
		public float Frequency { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Frequency = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Frequency);
			
		}
	}
	

}
