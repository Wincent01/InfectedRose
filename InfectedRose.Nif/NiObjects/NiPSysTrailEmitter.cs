using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Guild 2-Specific node
	///         
	/// </summary>
	public class NiPSysTrailEmitter : NiPSysEmitter
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
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
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat5 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat6 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat7 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt1 = reader.Read<int>();
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownFloat4 = reader.Read<float>();
			
			UnknownInt3 = reader.Read<int>();
			
			UnknownFloat5 = reader.Read<float>();
			
			UnknownInt4 = reader.Read<int>();
			
			UnknownFloat6 = reader.Read<float>();
			
			UnknownFloat7 = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownFloat4);
			
			writer.Write(UnknownInt3);
			
			writer.Write(UnknownFloat5);
			
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownFloat6);
			
			writer.Write(UnknownFloat7);
			
		}
	}
	

}
