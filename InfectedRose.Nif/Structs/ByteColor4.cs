using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A color with alpha (red, green, blue, alpha).
	///         
	/// </summary>
	public class ByteColor4 : IConstruct
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
		
		/// <summary>
		/// Alpha color component.
		/// </summary>
		public byte a { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			r = reader.Read<byte>();
			
			g = reader.Read<byte>();
			
			b = reader.Read<byte>();
			
			a = reader.Read<byte>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(r);
			
			writer.Write(g);
			
			writer.Write(b);
			
			writer.Write(a);
			
		}
	}
	

}
