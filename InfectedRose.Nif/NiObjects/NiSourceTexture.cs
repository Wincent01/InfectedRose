using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes texture source and properties.
	///         
	/// </summary>
	public class NiSourceTexture : NiTexture
	{
		/// <summary>
		/// Is the texture external?
		/// </summary>
		public byte UseExternal { get; set; } 
		
		/// <summary>
		/// The external texture file name.
		/// </summary>
		public FilePath FileName { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Ptr<NiObject> UnknownLink { get; set; }

		/// <summary>
		/// Pixel data object index. NiPixelData or NiPersistentSrcTextureRendererData
		/// </summary>
		public Ptr<ATextureRenderData> PixelData { get; set; } 
		
		/// <summary>
		/// Specifies the way the image will be stored.
		/// </summary>
		public PixelLayout PixelLayout { get; set; } 
		
		/// <summary>
		/// Specifies whether mip maps are used.
		/// </summary>
		public MipMapFormat UseMipmaps { get; set; } 
		
		/// <summary>
		///  Note: the NiTriShape linked to this object must have a NiAlphaProperty in its list of properties to enable material and/or texture transparency.
		/// </summary>
		public AlphaFormat AlphaFormat { get; set; } 
		
		/// <summary>
		/// Is Static?
		/// </summary>
		public byte IsStatic { get; set; } 
		
		/// <summary>
		/// Load direct to renderer
		/// </summary>
		public bool DirectRender { get; set; } 
		
		/// <summary>
		/// Render data is persistant
		/// </summary>
		public bool PersistRenderData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
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
				PixelData = reader.Read<Ptr<ATextureRenderData>>();
				
			}
			PixelLayout = (PixelLayout) reader.Read<uint>();
			
			UseMipmaps = (MipMapFormat) reader.Read<uint>();
			
			AlphaFormat = (AlphaFormat) reader.Read<uint>();
			
			IsStatic = reader.Read<byte>();
			
			DirectRender = reader.Read<byte>() != 0;
			
			PersistRenderData = reader.Read<byte>() != 0;
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
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
			writer.Write((uint) PixelLayout);
			
			writer.Write((uint) UseMipmaps);
			
			writer.Write((uint) AlphaFormat);
			
			writer.Write(IsStatic);
			
			writer.Write((byte) (DirectRender ? 1 : 0));
			
			writer.Write((byte) (PersistRenderData ? 1 : 0));
			
		}
	}
	

}
