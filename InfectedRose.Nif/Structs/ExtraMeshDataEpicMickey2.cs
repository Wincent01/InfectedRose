using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct ExtraMeshDataEpicMickey2 : IConstruct
	{
		/// <summary>
		/// 
		/// </summary>
		public int Start { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int End { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public short[] UnknownShorts { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Start = reader.Read<int>();
			
			End = reader.Read<int>();
			
			UnknownShorts = new short[10];
			for (var i = 0; i < 10; i++)
			{
				UnknownShorts[i] = reader.Read<short>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Start);
			
			writer.Write(End);
			
			for (var i = 0; i < 10; i++)
			{
				writer.Write(UnknownShorts[i]);
			}
			
		}
	}
	

}
