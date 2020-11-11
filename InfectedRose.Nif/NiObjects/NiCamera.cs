using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Camera object.
	///         
	/// </summary>
	public class NiCamera : NiAVObject
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Frustrum left.
		/// </summary>
		public float FrustumLeft { get; set; } 
		
		/// <summary>
		/// Frustrum right.
		/// </summary>
		public float FrustumRight { get; set; } 
		
		/// <summary>
		/// Frustrum top.
		/// </summary>
		public float FrustumTop { get; set; } 
		
		/// <summary>
		/// Frustrum bottom.
		/// </summary>
		public float FrustumBottom { get; set; } 
		
		/// <summary>
		/// Frustrum near.
		/// </summary>
		public float FrustumNear { get; set; } 
		
		/// <summary>
		/// Frustrum far.
		/// </summary>
		public float FrustumFar { get; set; } 
		
		/// <summary>
		/// Determines whether perspective is used.  Orthographic means no perspective.
		/// </summary>
		public bool UseOrthographicProjection { get; set; } 
		
		/// <summary>
		/// Viewport left.
		/// </summary>
		public float ViewportLeft { get; set; } 
		
		/// <summary>
		/// Viewport right.
		/// </summary>
		public float ViewportRight { get; set; } 
		
		/// <summary>
		/// Viewport top.
		/// </summary>
		public float ViewportTop { get; set; } 
		
		/// <summary>
		/// Viewport bottom.
		/// </summary>
		public float ViewportBottom { get; set; } 
		
		/// <summary>
		/// Level of detail adjust.
		/// </summary>
		public float LODAdjust { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Ptr<NiObject> UnknownLink { get; set; } 
		
		/// <summary>
		/// Unknown.  Changing value crashes viewer.
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Unknown.  Changing value crashes viewer.
		/// </summary>
		public uint UnknownInt2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<ushort>();
			
			FrustumLeft = reader.Read<float>();
			
			FrustumRight = reader.Read<float>();
			
			FrustumTop = reader.Read<float>();
			
			FrustumBottom = reader.Read<float>();
			
			FrustumNear = reader.Read<float>();
			
			FrustumFar = reader.Read<float>();
			
			UseOrthographicProjection = reader.Read<byte>() != 0;
			
			ViewportLeft = reader.Read<float>();
			
			ViewportRight = reader.Read<float>();
			
			ViewportTop = reader.Read<float>();
			
			ViewportBottom = reader.Read<float>();
			
			LODAdjust = reader.Read<float>();
			
			UnknownLink = reader.Read<Ptr<NiObject>>();
			
			UnknownInt = reader.Read<uint>();
			
			UnknownInt2 = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
			writer.Write(FrustumLeft);
			
			writer.Write(FrustumRight);
			
			writer.Write(FrustumTop);
			
			writer.Write(FrustumBottom);
			
			writer.Write(FrustumNear);
			
			writer.Write(FrustumFar);
			
			writer.Write((byte) (UseOrthographicProjection ? 1 : 0));
			
			writer.Write(ViewportLeft);
			
			writer.Write(ViewportRight);
			
			writer.Write(ViewportTop);
			
			writer.Write(ViewportBottom);
			
			writer.Write(LODAdjust);
			
			writer.Write(UnknownLink);
			
			writer.Write(UnknownInt);
			
			writer.Write(UnknownInt2);
			
		}
	}
	

}
