using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system modifier, used for controlling the particle velocity in a field like wind.
	///         
	/// </summary>
	public class NiPSysAirFieldModifier : NiPSysFieldModifier
	{
		/// <summary>
		/// Direction of the particle velocity
		/// </summary>
		public Vector3 Direction { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public bool UnknownBoolean1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public bool UnknownBoolean2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public bool UnknownBoolean3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat4 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Direction = new Vector3();
			Direction.Deserialize(reader);
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownBoolean1 = reader.Read<byte>() != 0;
			
			UnknownBoolean2 = reader.Read<byte>() != 0;
			
			UnknownBoolean3 = reader.Read<byte>() != 0;
			
			UnknownFloat4 = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Direction);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write((byte) (UnknownBoolean1 ? 1 : 0));
			
			writer.Write((byte) (UnknownBoolean2 ? 1 : 0));
			
			writer.Write((byte) (UnknownBoolean3 ? 1 : 0));
			
			writer.Write(UnknownFloat4);
			
		}
	}
	

}
