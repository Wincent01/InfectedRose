using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system modifier, used for controlling the particle velocity in force field.
	///         
	/// </summary>
	public class NiPSysVortexFieldModifier : NiPSysFieldModifier
	{
		/// <summary>
		/// Direction of the particle velocity
		/// </summary>
		public Vector3 Direction { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Direction = new Vector3();
			Direction.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Direction);
			
		}
	}
	

}
