using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXShapeDesc : NiObject
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
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
		public short UnknownShort1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public short UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt5 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt7 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt8 { get; set; } 
		
		/// <summary>
		/// PhysX Mesh Description
		/// </summary>
		public Ptr<NiPhysXMeshDesc> MeshDescription { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt1 = reader.Read<int>();
			
			UnknownQuat1 = new Quaternion();
			UnknownQuat1.Deserialize(reader);
			
			UnknownQuat2 = new Quaternion();
			UnknownQuat2.Deserialize(reader);
			
			UnknownQuat3 = new Quaternion();
			UnknownQuat3.Deserialize(reader);
			
			UnknownShort1 = reader.Read<short>();
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownShort2 = reader.Read<short>();
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownInt3 = reader.Read<int>();
			
			UnknownInt4 = reader.Read<int>();
			
			UnknownInt5 = reader.Read<int>();
			
			UnknownInt7 = reader.Read<int>();
			
			UnknownInt8 = reader.Read<int>();
			
			MeshDescription = reader.Read<Ptr<NiPhysXMeshDesc>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownQuat1);
			
			writer.Write(UnknownQuat2);
			
			writer.Write(UnknownQuat3);
			
			writer.Write(UnknownShort1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownShort2);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownInt3);
			
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownInt5);
			
			writer.Write(UnknownInt7);
			
			writer.Write(UnknownInt8);
			
			writer.Write(MeshDescription);
			
		}
	}
	

}
