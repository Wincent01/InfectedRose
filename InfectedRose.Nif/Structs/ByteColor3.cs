using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A color without alpha (red, green, blue).
	///         
	/// </summary>
	public class ByteColor3 : IConstruct
	{
		/// <summary>
		/// Red color component.
		/// </summary>
		public byte r { get; set; } 
		
		/// <summary>
		/// Green color component.
		/// </summary>
		public byte g { get; set; } 
		
		/// <summary>
		/// Blue color component.
		/// </summary>
		public byte b { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			r = reader.Read<byte>();
			
			g = reader.Read<byte>();
			
			b = reader.Read<byte>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(r);
			
			writer.Write(g);
			
			writer.Write(b);
			
		}
	}
	

}
