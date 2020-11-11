using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system modifier, used for controlling the particle
	///         velocity in force field.
	///         
	/// </summary>
	public class NiPSysRadialFieldModifier : NiPSysFieldModifier
	{
		/// <summary>
		/// Unknown Enums?
		/// </summary>
		public int RadialType { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			RadialType = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(RadialType);
			
		}
	}
	

}
