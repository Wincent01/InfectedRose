using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An array of bytes.
	///         
	/// </summary>
	public class ByteArray : IConstruct
	{
		/// <summary>
		/// The number of bytes in this array
		/// </summary>
		public uint DataSize { get; set; } 
		
		/// <summary>
		/// The bytes which make up the array
		/// </summary>
		public byte[] Data { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			DataSize = reader.Read<uint>();
			
			Data = new byte[DataSize];
			for (var i = 0; i < DataSize; i++)
			{
				Data[i] = reader.Read<byte>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(DataSize);
			
			for (var i = 0; i < DataSize; i++)
			{
				writer.Write(Data[i]);
			}
			
		}
	}
	

}
