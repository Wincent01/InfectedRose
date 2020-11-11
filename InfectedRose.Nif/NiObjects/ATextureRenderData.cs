using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ATextureRenderData : NiObject
	{
		/// <summary>
		/// The format of the pixels in this internally stored image.
		/// </summary>
		public PixelFormat PixelFormat { get; set; } 
		
		/// <summary>
		/// Bits per pixel, 0 (?), 8, 24 or 32.
		/// </summary>
		public byte BitsPerPixel { get; set; } 
		
		/// <summary>
		/// Unknown.  Could be reference pointer.
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Seems to always be zero.
		/// </summary>
		public uint UnknownInt3 { get; set; } 
		
		/// <summary>
		/// Flags
		/// </summary>
		public byte Flags { get; set; } 
		
		/// <summary>
		/// Unkown. Often zero.
		/// </summary>
		public uint UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// Channel Data
		/// </summary>
		public ChannelData[] Channels { get; set; } 
		
		/// <summary>
		/// Link to NiPalette, for 8-bit textures.
		/// </summary>
		public Ptr<NiPalette> Palette { get; set; } 
		
		/// <summary>
		/// Number of mipmaps in the texture.
		/// </summary>
		public uint NumMipmaps { get; set; } 
		
		/// <summary>
		/// Bytes per pixel (Bits Per Pixel / 8).
		/// </summary>
		public uint BytesPerPixel { get; set; } 
		
		/// <summary>
		/// Mipmap descriptions (width, height, offset).
		/// </summary>
		public MipMap[] Mipmaps { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			PixelFormat = (PixelFormat) reader.Read<uint>();
			
			BitsPerPixel = reader.Read<byte>();
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownInt3 = reader.Read<uint>();
			
			Flags = reader.Read<byte>();
			
			UnknownInt4 = reader.Read<uint>();
			
			UnknownByte1 = reader.Read<byte>();
			
			Channels = new ChannelData[4];
			for (var i = 0; i < 4; i++)
			{
				var value = new ChannelData();
				value.Deserialize(reader);
				Channels[i] = value;
			}
			
			Palette = reader.Read<Ptr<NiPalette>>();
			
			NumMipmaps = reader.Read<uint>();
			
			BytesPerPixel = reader.Read<uint>();
			
			Mipmaps = new MipMap[NumMipmaps];
			for (var i = 0; i < NumMipmaps; i++)
			{
				var value = new MipMap();
				value.Deserialize(reader);
				Mipmaps[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((uint) PixelFormat);
			
			writer.Write(BitsPerPixel);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownInt3);
			
			writer.Write(Flags);
			
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownByte1);
			
			for (var i = 0; i < 4; i++)
			{
				writer.Write(Channels[i]);
			}
			
			writer.Write(Palette);
			
			writer.Write(NumMipmaps);
			
			writer.Write(BytesPerPixel);
			
			for (var i = 0; i < NumMipmaps; i++)
			{
				writer.Write(Mipmaps[i]);
			}
			
		}
	}
	

}
