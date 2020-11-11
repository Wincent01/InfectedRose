using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         These nodes will always be rotated to face the camera creating a billboard effect for any attached objects.
	/// 
	///         In pre-10.1.0.0 the Flags field is used for BillboardMode.
	///         Bit 0: hidden
	///         Bits 1-2: collision mode
	///         Bit 3: unknown (set in most official meshes)
	///         Bits 5-6: billboard mode
	/// 
	///         Collision modes:
	///         00 NONE
	///         01 USE_TRIANGLES
	///         10 USE_OBBS
	///         11 CONTINUE
	/// 
	///         Billboard modes:
	///         00 ALWAYS_FACE_CAMERA
	///         01 ROTATE_ABOUT_UP
	///         10 RIGID_FACE_CAMERA
	///         11 ALWAYS_FACE_CENTER
	///         
	/// </summary>
	public class NiBillboardNode : NiNode
	{
		/// <summary>
		/// The way the billboard will react to the camera.
		/// </summary>
		public BillboardMode BillboardMode { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BillboardMode = (BillboardMode) reader.Read<ushort>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((ushort) BillboardMode);
			
		}
	}
	

}
