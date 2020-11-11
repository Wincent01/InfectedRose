using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct ExtraMeshDataEpicMickey : IConstruct
	{
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float UnknownInt4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float UnknownInt5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float UnknownInt6 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			UnknownInt1 = reader.Read<int>();
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownInt3 = reader.Read<int>();
			
			UnknownInt4 = reader.Read<float>();
			
			UnknownInt5 = reader.Read<float>();
			
			UnknownInt6 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownInt3);
			
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownInt5);
			
			writer.Write(UnknownInt6);
			
		}
	}
	

}
