using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXActorDesc : NiObject
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Quaternion UnknownQuat1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Quaternion UnknownQuat2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Quaternion UnknownQuat3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiPhysXBodyDesc> UnknownRef0 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt5 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt6 { get; set; } 
		
		/// <summary>
		/// PhysX Shape Description
		/// </summary>
		public Ptr<NiPhysXShapeDesc> ShapeDescription { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiObject> UnknownRef1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiObject> UnknownRef2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiObject>[] UnknownRefs3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt1 = reader.Read<int>();
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownQuat1 = new Quaternion();
			UnknownQuat1.Deserialize(reader);
			
			UnknownQuat2 = new Quaternion();
			UnknownQuat2.Deserialize(reader);
			
			UnknownQuat3 = new Quaternion();
			UnknownQuat3.Deserialize(reader);
			
			UnknownRef0 = reader.Read<Ptr<NiPhysXBodyDesc>>();
			
			UnknownInt4 = reader.Read<float>();
			
			UnknownInt5 = reader.Read<int>();
			
			UnknownByte1 = reader.Read<byte>();
			
			UnknownByte2 = reader.Read<byte>();
			
			UnknownInt6 = reader.Read<int>();
			
			ShapeDescription = reader.Read<Ptr<NiPhysXShapeDesc>>();
			
			UnknownRef1 = reader.Read<Ptr<NiObject>>();
			
			UnknownRef2 = reader.Read<Ptr<NiObject>>();
			
			UnknownRefs3 = new Ptr<NiObject>[UnknownInt6];
			for (var i = 0; i < UnknownInt6; i++)
			{
				UnknownRefs3[i] = reader.Read<Ptr<NiObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownQuat1);
			
			writer.Write(UnknownQuat2);
			
			writer.Write(UnknownQuat3);
			
			writer.Write(UnknownRef0);
			
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownInt5);
			
			writer.Write(UnknownByte1);
			
			writer.Write(UnknownByte2);
			
			writer.Write(UnknownInt6);
			
			writer.Write(ShapeDescription);
			
			writer.Write(UnknownRef1);
			
			writer.Write(UnknownRef2);
			
			for (var i = 0; i < UnknownInt6; i++)
			{
				writer.Write(UnknownRefs3[i]);
			}
			
		}
	}
	

}
