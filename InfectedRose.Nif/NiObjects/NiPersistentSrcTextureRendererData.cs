using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPersistentSrcTextureRendererData : ATextureRenderData
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public uint NumPixels { get; set; } 
		
		/// <summary>
		/// Unknown, same as the number of pixels? / number of blocks?
		/// </summary>
		public uint UnknownInt6 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint NumFaces { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt7 { get; set; } 
		
		/// <summary>
		/// Raw pixel data holding the mipmaps.  Mipmap zero is the full-size texture and they get smaller by half as the number increases.
		/// </summary>
		public byte[,] PixelData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumPixels = reader.Read<uint>();
			
			UnknownInt6 = reader.Read<uint>();
			
			NumFaces = reader.Read<uint>();
			
			UnknownInt7 = reader.Read<uint>();
			
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
			
			writer.Write(UnknownInt6);
			
			writer.Write(NumFaces);
			
			writer.Write(UnknownInt7);
			
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
