using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct AdditionalDataInfo : IConstruct
	{
		/// <summary>
		/// Type of data in this channel
		/// </summary>
		public int DataType { get; set; } 
		
		/// <summary>
		/// Number of bytes per element of this channel
		/// </summary>
		public int NumChannelBytesPerElement { get; set; } 
		
		/// <summary>
		/// Total number of bytes of this channel (num vertices times num bytes per element)
		/// </summary>
		public int NumChannelBytes { get; set; } 
		
		/// <summary>
		/// Number of bytes per element in all channels together. Sum of num channel bytes per element over all block infos.
		/// </summary>
		public int NumTotalBytesPerElement { get; set; } 
		
		/// <summary>
		/// Unsure. The block in which this channel is stored? Usually there is only one block, and so this is zero.
		/// </summary>
		public int BlockIndex { get; set; } 
		
		/// <summary>
		/// Offset (in bytes) of this channel. Sum of all num channel bytes per element of all preceeding block infos.
		/// </summary>
		public int ChannelOffset { get; set; } 
		
		/// <summary>
		/// Unknown, usually equal to 2.
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			DataType = reader.Read<int>();
			
			NumChannelBytesPerElement = reader.Read<int>();
			
			NumChannelBytes = reader.Read<int>();
			
			NumTotalBytesPerElement = reader.Read<int>();
			
			BlockIndex = reader.Read<int>();
			
			ChannelOffset = reader.Read<int>();
			
			UnknownByte1 = reader.Read<byte>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(DataType);
			
			writer.Write(NumChannelBytesPerElement);
			
			writer.Write(NumChannelBytes);
			
			writer.Write(NumTotalBytesPerElement);
			
			writer.Write(BlockIndex);
			
			writer.Write(ChannelOffset);
			
			writer.Write(UnknownByte1);
			
		}
	}
	

}
