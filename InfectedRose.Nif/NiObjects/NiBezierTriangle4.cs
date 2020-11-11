using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Sub data of NiBezierMesh
	///         
	/// </summary>
	public class NiBezierTriangle4 : NiObject
	{
		/// <summary>
		/// unknown
		/// </summary>
		public uint[] Unknown1 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public ushort Unknown2 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Matrix33 Matrix { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Vector3 Vector1 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Vector3 Vector2 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public short[] Unknown3 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public byte Unknown4 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public uint Unknown5 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public short[] Unknown6 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = new uint[6];
			for (var i = 0; i < 6; i++)
			{
				Unknown1[i] = reader.Read<uint>();
			}
			
			Unknown2 = reader.Read<ushort>();
			
			Matrix = new Matrix33();
			Matrix.Deserialize(reader);
			
			Vector1 = new Vector3();
			Vector1.Deserialize(reader);
			
			Vector2 = new Vector3();
			Vector2.Deserialize(reader);
			
			Unknown3 = new short[4];
			for (var i = 0; i < 4; i++)
			{
				Unknown3[i] = reader.Read<short>();
			}
			
			Unknown4 = reader.Read<byte>();
			
			Unknown5 = reader.Read<uint>();
			
			Unknown6 = new short[24];
			for (var i = 0; i < 24; i++)
			{
				Unknown6[i] = reader.Read<short>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 6; i++)
			{
				writer.Write(Unknown1[i]);
			}
			
			writer.Write(Unknown2);
			
			writer.Write(Matrix);
			
			writer.Write(Vector1);
			
			writer.Write(Vector2);
			
			for (var i = 0; i < 4; i++)
			{
				writer.Write(Unknown3[i]);
			}
			
			writer.Write(Unknown4);
			
			writer.Write(Unknown5);
			
			for (var i = 0; i < 24; i++)
			{
				writer.Write(Unknown6[i]);
			}
			
		}
	}
	

}
