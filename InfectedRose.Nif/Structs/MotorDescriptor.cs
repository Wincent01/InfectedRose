using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct MotorDescriptor : IConstruct
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
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
		public float UnknownFloat4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat5 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat6 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownFloat4 = reader.Read<float>();
			
			UnknownFloat5 = reader.Read<float>();
			
			UnknownFloat6 = reader.Read<float>();
			
			UnknownByte1 = reader.Read<byte>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownFloat4);
			
			writer.Write(UnknownFloat5);
			
			writer.Write(UnknownFloat6);
			
			writer.Write(UnknownByte1);
			
		}
	}
	

}
