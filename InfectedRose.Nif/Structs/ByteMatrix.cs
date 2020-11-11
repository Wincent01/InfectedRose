using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An array of bytes.
	///         
	/// </summary>
	public struct ByteMatrix : IConstruct
	{
		/// <summary>
		/// The number of bytes in this array
		/// </summary>
		public uint DataSize1 { get; set; } 
		
		/// <summary>
		/// The number of bytes in this array
		/// </summary>
		public uint DataSize2 { get; set; } 
		
		/// <summary>
		/// The bytes which make up the array
		/// </summary>
		public byte[,] Data { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			DataSize1 = reader.Read<uint>();
			
			DataSize2 = reader.Read<uint>();
			
			Data = new byte[DataSize2, DataSize1];
			for (var i = 0; i < DataSize2; i++)
			{
				for (var j = 0; j < DataSize1; j++)
				{
					Data[i, j] = reader.Read<byte>();
				}
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(DataSize1);
			
			writer.Write(DataSize2);
			
			for (var i = 0; i < DataSize2; i++)
			{
				for (var j = 0; j < DataSize1; j++)
				{
					writer.Write(Data[i, j]);
				}
			}
			
		}
	}
	

}
