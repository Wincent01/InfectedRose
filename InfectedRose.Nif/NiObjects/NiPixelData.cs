using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A texture.
	///         
	/// </summary>
	public class NiPixelData : ATextureRenderData
	{
		/// <summary>
		/// Total number of pixels
		/// </summary>
		public uint NumPixels { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint NumFaces { get; set; } 
		
		/// <summary>
		/// Raw pixel data holding the mipmaps.  Mipmap zero is the full-size texture and they get smaller by half as the number increases.
		/// </summary>
		public byte[,] PixelData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumPixels = reader.Read<uint>();
			
			NumFaces = reader.Read<uint>();
			
			PixelData = new byte[NumFaces, NumPixels];
			for (var i = 0; i < NumFaces; i++)
			{
				for (var j = 0; j < NumPixels; j++)
				{
					PixelData[i, j] = reader.Read<byte>();
				}
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumPixels);
			
			writer.Write(NumFaces);
			
			for (var i = 0; i < NumFaces; i++)
			{
				for (var j = 0; j < NumPixels; j++)
				{
					writer.Write(PixelData[i, j]);
				}
			}
			
		}
	}
	

}
