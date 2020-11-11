using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Another string format, for short strings.  Specific to Bethesda-specific header tags.
	///         
	/// </summary>
	public struct ShortString : IConstruct
	{
		/// <summary>
		/// The string length.
		/// </summary>
		public byte Length { get; set; } 
		
		/// <summary>
		/// The string itself, null terminated (the null terminator is taken into account in the length byte).
		/// </summary>
		public byte[] Value { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Length = reader.Read<byte>();
			
			Value = new byte[Length];
			for (var i = 0; i < Length; i++)
			{
				Value[i] = reader.Read<byte>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Length);
			
			for (var i = 0; i < Length; i++)
			{
				writer.Write(Value[i]);
			}
			
		}
	}
	

}
