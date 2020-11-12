using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class SkinPartitionUnknownItem1 : IConstruct
	{
		/// <summary>
		/// 
		/// </summary>
		public uint UnknownFlags { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float f1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float f2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float f3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float f4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float f5 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			UnknownFlags = reader.Read<uint>();
			
			f1 = reader.Read<float>();
			
			f2 = reader.Read<float>();
			
			f3 = reader.Read<float>();
			
			f4 = reader.Read<float>();
			
			f5 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(UnknownFlags);
			
			writer.Write(f1);
			
			writer.Write(f2);
			
			writer.Write(f3);
			
			writer.Write(f4);
			
			writer.Write(f5);
			
		}
	}
	

}
