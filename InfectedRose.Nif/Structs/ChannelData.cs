using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Channel data
	///         
	/// </summary>
	public class ChannelData : IConstruct
	{
		/// <summary>
		/// Channel Type
		/// </summary>
		public ChannelType Type { get; set; } 
		
		/// <summary>
		/// Data Storage Convention
		/// </summary>
		public ChannelConvention Convention { get; set; } 
		
		/// <summary>
		/// Bits per channel
		/// </summary>
		public byte BitsPerChannel { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Type = (ChannelType) reader.Read<uint>();
			
			Convention = (ChannelConvention) reader.Read<uint>();
			
			BitsPerChannel = reader.Read<byte>();
			
			UnknownByte1 = reader.Read<byte>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write((uint) Type);
			
			writer.Write((uint) Convention);
			
			writer.Write(BitsPerChannel);
			
			writer.Write(UnknownByte1);
			
		}
	}
	

}
