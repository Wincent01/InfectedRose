using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A texture source.
	///         
	/// </summary>
	public class TexSource : IConstruct
	{
		/// <summary>
		/// Is the texture external?
		/// </summary>
		public byte UseExternal { get; set; } 
		
		/// <summary>
		/// 
		///             The external texture file name.
		/// 
		///             Note: all original morrowind nifs use name.ext only for addressing the textures, but most mods use something like textures/[subdir/]name.ext. This is due to a feature in Morrowind resource manager: it loads name.ext, textures/name.ext and textures/subdir/name.ext but NOT subdir/name.ext.
		///         
		/// </summary>
		public FilePath FileName { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Ptr<NiObject> UnknownLink { get; set; } 
		
		/// <summary>
		/// Pixel data object index.
		/// </summary>
		public Ptr<NiPixelData> PixelData { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			UseExternal = reader.Read<byte>();
			
			if (UseExternal==1)
			{
				FileName = new FilePath();
				FileName.Deserialize(reader);
				
			}
			if (UseExternal==1)
			{
				UnknownLink = reader.Read<Ptr<NiObject>>();
				
			}
			if (UseExternal==0)
			{
				FileName = new FilePath();
				FileName.Deserialize(reader);
				
			}
			if (UseExternal==0)
			{
				PixelData = reader.Read<Ptr<NiPixelData>>();
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(UseExternal);
			
			if (UseExternal==1)
			{
				writer.Write(FileName);
				
			}
			if (UseExternal==1)
			{
				writer.Write(UnknownLink);
				
			}
			if (UseExternal==0)
			{
				writer.Write(FileName);
				
			}
			if (UseExternal==0)
			{
				writer.Write(PixelData);
				
			}
		}
	}
	

}
