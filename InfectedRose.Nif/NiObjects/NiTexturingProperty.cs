using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes an object's textures.
	///         
	/// </summary>
	public class NiTexturingProperty : NiProperty
	{
		/// <summary>
		/// Property flags.
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Number of textures. Always 7 in versions < 20.0.0.4. Can also be 8 in >= 20.0.0.4.
		/// </summary>
		public uint TextureCount { get; set; } 
		
		/// <summary>
		/// Do we have a base texture?
		/// </summary>
		public bool HasBaseTexture { get; set; } 
		
		/// <summary>
		/// The base texture.
		/// </summary>
		public TexDesc BaseTexture { get; set; } 
		
		/// <summary>
		/// Do we have a dark texture?
		/// </summary>
		public bool HasDarkTexture { get; set; } 
		
		/// <summary>
		/// The dark texture.
		/// </summary>
		public TexDesc DarkTexture { get; set; } 
		
		/// <summary>
		/// Do we have a detail texture?
		/// </summary>
		public bool HasDetailTexture { get; set; } 
		
		/// <summary>
		/// The detail texture.
		/// </summary>
		public TexDesc DetailTexture { get; set; } 
		
		/// <summary>
		/// Do we have a gloss texture?
		/// </summary>
		public bool HasGlossTexture { get; set; } 
		
		/// <summary>
		/// The gloss texture.
		/// </summary>
		public TexDesc GlossTexture { get; set; } 
		
		/// <summary>
		/// Do we have a glow texture?
		/// </summary>
		public bool HasGlowTexture { get; set; } 
		
		/// <summary>
		/// The glowing texture.
		/// </summary>
		public TexDesc GlowTexture { get; set; } 
		
		/// <summary>
		/// Do we have a bump map texture?
		/// </summary>
		public bool HasBumpMapTexture { get; set; } 
		
		/// <summary>
		/// The bump map texture.
		/// </summary>
		public TexDesc BumpMapTexture { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float BumpMapLumaScale { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float BumpMapLumaOffset { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Matrix22 BumpMapMatrix { get; set; } 
		
		/// <summary>
		/// Do we have a normal texture?  (Noraml guess based on file suffix in sample files)
		/// </summary>
		public bool HasNormalTexture { get; set; } 
		
		/// <summary>
		/// Normal texture.
		/// </summary>
		public TexDesc NormalTexture { get; set; } 
		
		/// <summary>
		/// Do we have a unknown texture 2?
		/// </summary>
		public bool HasUnknown2Texture { get; set; } 
		
		/// <summary>
		/// Unknown texture 2.
		/// </summary>
		public TexDesc Unknown2Texture { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float Unknown2Float { get; set; } 
		
		/// <summary>
		/// Do we have a decal 0 texture?
		/// </summary>
		public bool HasDecal0Texture { get; set; } 
		
		/// <summary>
		/// The decal texture.
		/// </summary>
		public TexDesc Decal0Texture { get; set; } 
		
		/// <summary>
		/// Do we have a decal 1 texture?
		/// </summary>
		public bool HasDecal1Texture { get; set; } 
		
		/// <summary>
		/// Another decal texture.
		/// </summary>
		public TexDesc Decal1Texture { get; set; } 
		
		/// <summary>
		/// Do we have a decal 2 texture?
		/// </summary>
		public bool HasDecal2Texture { get; set; } 
		
		/// <summary>
		/// Another decal texture.
		/// </summary>
		public TexDesc Decal2Texture { get; set; } 
		
		/// <summary>
		/// Do we have a decal 3 texture?
		/// </summary>
		public bool HasDecal3Texture { get; set; } 
		
		/// <summary>
		/// Another decal texture. Who knows the limit.
		/// </summary>
		public TexDesc Decal3Texture { get; set; } 
		
		/// <summary>
		/// Number of Shader textures that follow.
		/// </summary>
		public uint NumShaderTextures { get; set; } 
		
		/// <summary>
		/// Shader textures.
		/// </summary>
		public ShaderTexDesc[] ShaderTextures { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			TextureCount = reader.Read<uint>();
			
			HasBaseTexture = reader.Read<byte>() != 0;
			
			if (HasBaseTexture)
			{
				BaseTexture = new TexDesc();
				BaseTexture.Deserialize(reader);
				
			}
			HasDarkTexture = reader.Read<byte>() != 0;
			
			if (HasDarkTexture)
			{
				DarkTexture = new TexDesc();
				DarkTexture.Deserialize(reader);
				
			}
			HasDetailTexture = reader.Read<byte>() != 0;
			
			if (HasDetailTexture)
			{
				DetailTexture = new TexDesc();
				DetailTexture.Deserialize(reader);
				
			}
			HasGlossTexture = reader.Read<byte>() != 0;
			
			if (HasGlossTexture)
			{
				GlossTexture = new TexDesc();
				GlossTexture.Deserialize(reader);
				
			}
			HasGlowTexture = reader.Read<byte>() != 0;
			
			if (HasGlowTexture)
			{
				GlowTexture = new TexDesc();
				GlowTexture.Deserialize(reader);
				
			}
			HasBumpMapTexture = reader.Read<byte>() != 0;
			
			if (HasBumpMapTexture)
			{
				BumpMapTexture = new TexDesc();
				BumpMapTexture.Deserialize(reader);
				
			}
			if (HasBumpMapTexture)
			{
				BumpMapLumaScale = reader.Read<float>();
				
			}
			if (HasBumpMapTexture)
			{
				BumpMapLumaOffset = reader.Read<float>();
				
			}
			if (HasBumpMapTexture)
			{
				BumpMapMatrix = new Matrix22();
				BumpMapMatrix.Deserialize(reader);
				
			}
			HasNormalTexture = reader.Read<byte>() != 0;
			
			if (HasNormalTexture)
			{
				NormalTexture = new TexDesc();
				NormalTexture.Deserialize(reader);
				
			}
			HasUnknown2Texture = reader.Read<byte>() != 0;
			
			if (HasUnknown2Texture)
			{
				Unknown2Texture = new TexDesc();
				Unknown2Texture.Deserialize(reader);
				
			}
			if (HasUnknown2Texture)
			{
				Unknown2Float = reader.Read<float>();
				
			}
			HasDecal0Texture = reader.Read<byte>() != 0;
			
			if (HasDecal0Texture)
			{
				Decal0Texture = new TexDesc();
				Decal0Texture.Deserialize(reader);
				
			}
			if (TextureCount>=10)
			{
				HasDecal1Texture = reader.Read<byte>() != 0;
				
			}
			if (HasDecal1Texture)
			{
				Decal1Texture = new TexDesc();
				Decal1Texture.Deserialize(reader);
				
			}
			if (TextureCount>=11)
			{
				HasDecal2Texture = reader.Read<byte>() != 0;
				
			}
			if (HasDecal2Texture)
			{
				Decal2Texture = new TexDesc();
				Decal2Texture.Deserialize(reader);
				
			}
			if (TextureCount>=12)
			{
				HasDecal3Texture = reader.Read<byte>() != 0;
				
			}
			if (HasDecal3Texture)
			{
				Decal3Texture = new TexDesc();
				Decal3Texture.Deserialize(reader);
				
			}
			NumShaderTextures = reader.Read<uint>();
			
			ShaderTextures = new ShaderTexDesc[NumShaderTextures];
			for (var i = 0; i < NumShaderTextures; i++)
			{
				var value = new ShaderTexDesc();
				value.Deserialize(reader);
				ShaderTextures[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(TextureCount);
			
			writer.Write((byte) (HasBaseTexture ? 1 : 0));
			
			if (HasBaseTexture)
			{
				writer.Write(BaseTexture);
				
			}
			writer.Write((byte) (HasDarkTexture ? 1 : 0));
			
			if (HasDarkTexture)
			{
				writer.Write(DarkTexture);
				
			}
			writer.Write((byte) (HasDetailTexture ? 1 : 0));
			
			if (HasDetailTexture)
			{
				writer.Write(DetailTexture);
				
			}
			writer.Write((byte) (HasGlossTexture ? 1 : 0));
			
			if (HasGlossTexture)
			{
				writer.Write(GlossTexture);
				
			}
			writer.Write((byte) (HasGlowTexture ? 1 : 0));
			
			if (HasGlowTexture)
			{
				writer.Write(GlowTexture);
				
			}
			writer.Write((byte) (HasBumpMapTexture ? 1 : 0));
			
			if (HasBumpMapTexture)
			{
				writer.Write(BumpMapTexture);
				
			}
			if (HasBumpMapTexture)
			{
				writer.Write(BumpMapLumaScale);
				
			}
			if (HasBumpMapTexture)
			{
				writer.Write(BumpMapLumaOffset);
				
			}
			if (HasBumpMapTexture)
			{
				writer.Write(BumpMapMatrix);
				
			}
			writer.Write((byte) (HasNormalTexture ? 1 : 0));
			
			if (HasNormalTexture)
			{
				writer.Write(NormalTexture);
				
			}
			writer.Write((byte) (HasUnknown2Texture ? 1 : 0));
			
			if (HasUnknown2Texture)
			{
				writer.Write(Unknown2Texture);
				
			}
			if (HasUnknown2Texture)
			{
				writer.Write(Unknown2Float);
				
			}
			writer.Write((byte) (HasDecal0Texture ? 1 : 0));
			
			if (HasDecal0Texture)
			{
				writer.Write(Decal0Texture);
				
			}
			if (TextureCount>=10)
			{
				writer.Write((byte) (HasDecal1Texture ? 1 : 0));
				
			}
			if (HasDecal1Texture)
			{
				writer.Write(Decal1Texture);
				
			}
			if (TextureCount>=11)
			{
				writer.Write((byte) (HasDecal2Texture ? 1 : 0));
				
			}
			if (HasDecal2Texture)
			{
				writer.Write(Decal2Texture);
				
			}
			if (TextureCount>=12)
			{
				writer.Write((byte) (HasDecal3Texture ? 1 : 0));
				
			}
			if (HasDecal3Texture)
			{
				writer.Write(Decal3Texture);
				
			}
			writer.Write(NumShaderTextures);
			
			for (var i = 0; i < NumShaderTextures; i++)
			{
				writer.Write(ShaderTextures[i]);
			}
			
		}
	}
	

}
