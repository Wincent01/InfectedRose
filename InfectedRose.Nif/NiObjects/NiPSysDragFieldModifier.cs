using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system modifier, used for controlling the particle velocity in drag space warp.
	///         
	/// </summary>
	public class NiPSysDragFieldModifier : NiPSysFieldModifier
	{
		/// <summary>
		/// Whether to use the direction field?
		/// </summary>
		public bool UseDirection { get; set; } 
		
		/// <summary>
		/// Direction of the particle velocity
		/// </summary>
		public Vector3 Direction { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UseDirection = reader.Read<byte>() != 0;
			
			Direction = new Vector3();
			Direction.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((byte) (UseDirection ? 1 : 0));
			
			writer.Write(Direction);
			
		}
	}
	

}
