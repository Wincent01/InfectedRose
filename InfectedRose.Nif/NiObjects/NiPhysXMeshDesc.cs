using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXMeshDesc : NiObject
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public short UnknownShort1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public short UnknownShort2 { get; set; } 
		
		/// <summary>
		/// NXS
		/// </summary>
		public byte[] UnknownBytes0 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// MESH
		/// </summary>
		public byte[] UnknownBytes1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte[] UnknownBytes2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Number of mesh vertices
		/// </summary>
		public int NumVertices { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Vertices
		/// </summary>
		public Vector3[] Vertices { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte[] UnknownBytes3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public short[] UnknownShorts1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint[] UnknownInts1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort1 = reader.Read<short>();
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownShort2 = reader.Read<short>();
			
			UnknownBytes0 = new byte[3];
			for (var i = 0; i < 3; i++)
			{
				UnknownBytes0[i] = reader.Read<byte>();
			}
			
			UnknownByte1 = reader.Read<byte>();
			
			UnknownBytes1 = new byte[4];
			for (var i = 0; i < 4; i++)
			{
				UnknownBytes1[i] = reader.Read<byte>();
			}
			
			UnknownBytes2 = new byte[8];
			for (var i = 0; i < 8; i++)
			{
				UnknownBytes2[i] = reader.Read<byte>();
			}
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownInt1 = reader.Read<int>();
			
			UnknownInt2 = reader.Read<int>();
			
			NumVertices = reader.Read<int>();
			
			UnknownInt4 = reader.Read<int>();
			
			Vertices = new Vector3[NumVertices];
			for (var i = 0; i < NumVertices; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Vertices[i] = value;
			}
			
			UnknownBytes3 = new byte[982];
			for (var i = 0; i < 982; i++)
			{
				UnknownBytes3[i] = reader.Read<byte>();
			}
			
			UnknownShorts1 = new short[368];
			for (var i = 0; i < 368; i++)
			{
				UnknownShorts1[i] = reader.Read<short>();
			}
			
			UnknownInts1 = new uint[3328];
			for (var i = 0; i < 3328; i++)
			{
				UnknownInts1[i] = reader.Read<uint>();
			}
			
			UnknownByte2 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort1);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownShort2);
			
			for (var i = 0; i < 3; i++)
			{
				writer.Write(UnknownBytes0[i]);
			}
			
			writer.Write(UnknownByte1);
			
			for (var i = 0; i < 4; i++)
			{
				writer.Write(UnknownBytes1[i]);
			}
			
			for (var i = 0; i < 8; i++)
			{
				writer.Write(UnknownBytes2[i]);
			}
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(NumVertices);
			
			writer.Write(UnknownInt4);
			
			for (var i = 0; i < NumVertices; i++)
			{
				writer.Write(Vertices[i]);
			}
			
			for (var i = 0; i < 982; i++)
			{
				writer.Write(UnknownBytes3[i]);
			}
			
			for (var i = 0; i < 368; i++)
			{
				writer.Write(UnknownShorts1[i]);
			}
			
			for (var i = 0; i < 3328; i++)
			{
				writer.Write(UnknownInts1[i]);
			}
			
			writer.Write(UnknownByte2);
			
		}
	}
	

}
