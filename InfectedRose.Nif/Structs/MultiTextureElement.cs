using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class MultiTextureElement : IConstruct
	{
		/// <summary>
		/// Looks like a memory address, so probably a bool.
		/// </summary>
		public bool HasImage { get; set; } 
		
		/// <summary>
		/// Link to the texture image.
		/// </summary>
		public Ptr<NiImage> Image { get; set; } 
		
		/// <summary>
		/// May be texture clamp mode.
		/// </summary>
		public TexClampMode Clamp { get; set; } 
		
		/// <summary>
		/// May be texture filter mode.
		/// </summary>
		public TexFilterMode Filter { get; set; } 
		
		/// <summary>
		/// This may be the UV set counting from 1 instead of zero.
		/// </summary>
		public uint UVSet { get; set; } 
		
		/// <summary>
		/// Unknown.  Usually 0 but sometimes 257
		/// </summary>
		public short UnknownShort3 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			HasImage = reader.Read<byte>() != 0;
			
			if (HasImage)
			{
				Image = reader.Read<Ptr<NiImage>>();
				
			}
			if (HasImage)
			{
				Clamp = (TexClampMode) reader.Read<uint>();
				
			}
			if (HasImage)
			{
				Filter = (TexFilterMode) reader.Read<uint>();
				
			}
			if (HasImage)
			{
				UVSet = reader.Read<uint>();
				
			}
			if (HasImage)
			{
				UnknownShort3 = reader.Read<short>();
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write((byte) (HasImage ? 1 : 0));
			
			if (HasImage)
			{
				writer.Write(Image);
				
			}
			if (HasImage)
			{
				writer.Write((uint) Clamp);
				
			}
			if (HasImage)
			{
				writer.Write((uint) Filter);
				
			}
			if (HasImage)
			{
				writer.Write(UVSet);
				
			}
			if (HasImage)
			{
				writer.Write(UnknownShort3);
				
			}
		}
	}
	

}
