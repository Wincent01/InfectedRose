using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Texture description.
	///         
	/// </summary>
	public struct TexDesc : IConstruct
	{
		/// <summary>
		/// NiSourceTexture object index.
		/// </summary>
		public Ptr<NiSourceTexture> Source { get; set; } 
		
		/// <summary>
		/// Texture mode flags; clamp and filter mode stored in upper byte with 0xYZ00 = clamp mode Y, filter mode Z.
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Determines whether or not the texture's coordinates are transformed.
		/// </summary>
		public bool HasTextureTransform { get; set; } 
		
		/// <summary>
		/// The amount to translate the texture coordinates in each direction?
		/// </summary>
		public TexCoord Translation { get; set; } 
		
		/// <summary>
		/// The number of times the texture is tiled in each direction?
		/// </summary>
		public TexCoord Tiling { get; set; } 
		
		/// <summary>
		/// 2D Rotation of texture image around third W axis after U and V.
		/// </summary>
		public float WRotation { get; set; } 
		
		/// <summary>
		/// The texture transform type?  Doesn't seem to do anything.
		/// </summary>
		public uint TransformType { get; set; } 
		
		/// <summary>
		/// The offset from the origin?
		/// </summary>
		public TexCoord CenterOffset { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Source = reader.Read<Ptr<NiSourceTexture>>();
			
			Flags = reader.Read<ushort>();
			
			HasTextureTransform = reader.Read<byte>() != 0;
			
			if (HasTextureTransform)
			{
				Translation = new TexCoord();
				Translation.Deserialize(reader);
				
			}
			if (HasTextureTransform)
			{
				Tiling = new TexCoord();
				Tiling.Deserialize(reader);
				
			}
			if (HasTextureTransform)
			{
				WRotation = reader.Read<float>();
				
			}
			if (HasTextureTransform)
			{
				TransformType = reader.Read<uint>();
				
			}
			if (HasTextureTransform)
			{
				CenterOffset = new TexCoord();
				CenterOffset.Deserialize(reader);
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Source);
			
			writer.Write(Flags);
			
			writer.Write((byte) (HasTextureTransform ? 1 : 0));
			
			if (HasTextureTransform)
			{
				writer.Write(Translation);
				
			}
			if (HasTextureTransform)
			{
				writer.Write(Tiling);
				
			}
			if (HasTextureTransform)
			{
				writer.Write(WRotation);
				
			}
			if (HasTextureTransform)
			{
				writer.Write(TransformType);
				
			}
			if (HasTextureTransform)
			{
				writer.Write(CenterOffset);
				
			}
		}
	}
	

}
