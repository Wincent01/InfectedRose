using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Enables environment mapping. Should be in both the children list and effects list of the NiTriShape object. For Morrowind: the bump map can be used to bump the environment map (note that the bump map is ignored if no NiTextureEffect object is present).
	///         
	/// </summary>
	public class NiTextureEffect : NiDynamicEffect
	{
		/// <summary>
		/// Model projection matrix.  Always identity?
		/// </summary>
		public Matrix33 ModelProjectionMatrix { get; set; } 
		
		/// <summary>
		/// Model projection transform.  Always (0,0,0)?
		/// </summary>
		public Vector3 ModelProjectionTransform { get; set; } 
		
		/// <summary>
		/// Texture Filtering mode.
		/// </summary>
		public TexFilterMode TextureFiltering { get; set; } 
		
		/// <summary>
		/// Texture Clamp mode.
		/// </summary>
		public TexClampMode TextureClamping { get; set; } 
		
		/// <summary>
		/// The type of effect that the texture is used for.
		/// </summary>
		public EffectType TextureType { get; set; } 
		
		/// <summary>
		/// The method that will be used to generate UV coordinates for the texture effect.
		/// </summary>
		public CoordGenType CoordinateGenerationType { get; set; } 
		
		/// <summary>
		/// Source texture index.
		/// </summary>
		public Ptr<NiSourceTexture> SourceTexture { get; set; } 
		
		/// <summary>
		/// Determines whether a clipping plane is used.  0 means that a plane is not used.
		/// </summary>
		public byte ClippingPlane { get; set; } 
		
		/// <summary>
		/// Unknown: (1,0,0)?
		/// </summary>
		public Vector3 UnknownVector { get; set; } 
		
		/// <summary>
		/// Unknown. 0?
		/// </summary>
		public float UnknownFloat { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ModelProjectionMatrix = new Matrix33();
			ModelProjectionMatrix.Deserialize(reader);
			
			ModelProjectionTransform = new Vector3();
			ModelProjectionTransform.Deserialize(reader);
			
			TextureFiltering = (TexFilterMode) reader.Read<uint>();
			
			TextureClamping = (TexClampMode) reader.Read<uint>();
			
			TextureType = (EffectType) reader.Read<uint>();
			
			CoordinateGenerationType = (CoordGenType) reader.Read<uint>();
			
			SourceTexture = reader.Read<Ptr<NiSourceTexture>>();
			
			ClippingPlane = reader.Read<byte>();
			
			UnknownVector = new Vector3();
			UnknownVector.Deserialize(reader);
			
			UnknownFloat = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ModelProjectionMatrix);
			
			writer.Write(ModelProjectionTransform);
			
			writer.Write((uint) TextureFiltering);
			
			writer.Write((uint) TextureClamping);
			
			writer.Write((uint) TextureType);
			
			writer.Write((uint) CoordinateGenerationType);
			
			writer.Write(SourceTexture);
			
			writer.Write(ClippingPlane);
			
			writer.Write(UnknownVector);
			
			writer.Write(UnknownFloat);
			
		}
	}
	

}
