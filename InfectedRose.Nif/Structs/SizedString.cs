using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A string of given length.
	///         
	/// </summary>
	public struct SizedString : IConstruct
	{
		/// <summary>
		/// The string length.
		/// </summary>
		public uint Length { get; set; } 
		
		/// <summary>
		/// The string itself.
		/// </summary>
		public byte[] Value { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Length = reader.Read<uint>();
			
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
