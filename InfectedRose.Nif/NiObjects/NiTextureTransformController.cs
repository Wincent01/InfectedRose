using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Texture transformation controller. The target texture slot should have "Has Texture Transform" enabled.
	///         
	/// </summary>
	public class NiTextureTransformController : NiFloatInterpController
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte Unknown2 { get; set; } 
		
		/// <summary>
		///  The target texture slot.
		/// </summary>
		public TexType TextureSlot { get; set; } 
		
		/// <summary>
		/// Determines how this controller animates the UV Coordinates.
		/// </summary>
		public TexTransform Operation { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown2 = reader.Read<byte>();
			
			TextureSlot = (TexType) reader.Read<uint>();
			
			Operation = (TexTransform) reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown2);
			
			writer.Write((uint) TextureSlot);
			
			writer.Write((uint) Operation);
			
		}
	}
	

}
