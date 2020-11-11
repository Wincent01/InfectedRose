using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Description of a MipMap within a NiPixelData object.
	///         
	/// </summary>
	public struct MipMap : IConstruct
	{
		/// <summary>
		/// Width of the mipmap image.
		/// </summary>
		public uint Width { get; set; } 
		
		/// <summary>
		/// Height of the mipmap image.
		/// </summary>
		public uint Height { get; set; } 
		
		/// <summary>
		/// Offset into the pixel data array where this mipmap starts.
		/// </summary>
		public uint Offset { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Width = reader.Read<uint>();
			
			Height = reader.Read<uint>();
			
			Offset = reader.Read<uint>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Width);
			
			writer.Write(Height);
			
			writer.Write(Offset);
			
		}
	}
	

}
