using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Raw image data.
	///         
	/// </summary>
	public class NiRawImageData : NiObject
	{
		/// <summary>
		/// Image width
		/// </summary>
		public uint Width { get; set; } 
		
		/// <summary>
		/// Image height
		/// </summary>
		public uint Height { get; set; } 
		
		/// <summary>
		/// The format of the raw image data.
		/// </summary>
		public ImageType ImageType { get; set; } 
		
		/// <summary>
		/// Image pixel data.
		/// </summary>
		public ByteColor3[,] RGBImageData { get; set; } 
		
		/// <summary>
		/// Image pixel data.
		/// </summary>
		public ByteColor4[,] RGBAImageData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Width = reader.Read<uint>();
			
			Height = reader.Read<uint>();
			
			ImageType = (ImageType) reader.Read<uint>();
			
			if (ImageType==(ImageType) 1)
			{
				RGBImageData = new ByteColor3[Width, Height];
				for (var i = 0; i < Width; i++)
				{
					for (var j = 0; j < Height; j++)
					{
						var value = new ByteColor3();
						value.Deserialize(reader);
						RGBImageData[i, j] = value;
					}
				}
				
			}
			if (ImageType==(ImageType) 2)
			{
				RGBAImageData = new ByteColor4[Width, Height];
				for (var i = 0; i < Width; i++)
				{
					for (var j = 0; j < Height; j++)
					{
						var value = new ByteColor4();
						value.Deserialize(reader);
						RGBAImageData[i, j] = value;
					}
				}
				
			}
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Width);
			
			writer.Write(Height);
			
			writer.Write((uint) ImageType);
			
			if (ImageType==(ImageType) 1)
			{
				for (var i = 0; i < Width; i++)
				{
					for (var j = 0; j < Height; j++)
					{
						writer.Write(RGBImageData[i, j]);
					}
				}
				
			}
			if (ImageType==(ImageType)2)
			{
				for (var i = 0; i < Width; i++)
				{
					for (var j = 0; j < Height; j++)
					{
						writer.Write(RGBAImageData[i, j]);
					}
				}
				
			}
		}
	}
	

}
