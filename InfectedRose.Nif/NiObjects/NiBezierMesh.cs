using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown
	///         
	/// </summary>
	public class NiBezierMesh : NiAVObject
	{
		/// <summary>
		/// references.
		/// </summary>
		public uint NumBezierTriangles { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Ptr<NiBezierTriangle4>[] BezierTriangle { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint Unknown3 { get; set; } 
		
		/// <summary>
		/// Data count.
		/// </summary>
		public ushort Count1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort Unknown4 { get; set; } 
		
		/// <summary>
		/// data.
		/// </summary>
		public Vector3[] Points1 { get; set; } 
		
		/// <summary>
		/// Unknown (illegal link?).
		/// </summary>
		public uint Unknown5 { get; set; } 
		
		/// <summary>
		/// data.
		/// </summary>
		public float[,] Points2 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public uint Unknown6 { get; set; } 
		
		/// <summary>
		/// data count 2.
		/// </summary>
		public ushort Count2 { get; set; } 
		
		/// <summary>
		/// data count.
		/// </summary>
		public ushort[,] Data2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumBezierTriangles = reader.Read<uint>();
			
			BezierTriangle = new Ptr<NiBezierTriangle4>[NumBezierTriangles];
			for (var i = 0; i < NumBezierTriangles; i++)
			{
				BezierTriangle[i] = reader.Read<Ptr<NiBezierTriangle4>>();
			}
			
			Unknown3 = reader.Read<uint>();
			
			Count1 = reader.Read<ushort>();
			
			Unknown4 = reader.Read<ushort>();
			
			Points1 = new Vector3[Count1];
			for (var i = 0; i < Count1; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Points1[i] = value;
			}
			
			Unknown5 = reader.Read<uint>();
			
			Points2 = new float[Count1, 2];
			for (var i = 0; i < Count1; i++)
			{
				for (var j = 0; j < 2; j++)
				{
					Points2[i, j] = reader.Read<float>();
				}
			}
			
			Unknown6 = reader.Read<uint>();
			
			Count2 = reader.Read<ushort>();
			
			Data2 = new ushort[Count2, 4];
			for (var i = 0; i < Count2; i++)
			{
				for (var j = 0; j < 4; j++)
				{
					Data2[i, j] = reader.Read<ushort>();
				}
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumBezierTriangles);
			
			for (var i = 0; i < NumBezierTriangles; i++)
			{
				writer.Write(BezierTriangle[i]);
			}
			
			writer.Write(Unknown3);
			
			writer.Write(Count1);
			
			writer.Write(Unknown4);
			
			for (var i = 0; i < Count1; i++)
			{
				writer.Write(Points1[i]);
			}
			
			writer.Write(Unknown5);
			
			for (var i = 0; i < Count1; i++)
			{
				for (var j = 0; j < 2; j++)
				{
					writer.Write(Points2[i, j]);
				}
			}
			
			writer.Write(Unknown6);
			
			writer.Write(Count2);
			
			for (var i = 0; i < Count2; i++)
			{
				for (var j = 0; j < 4; j++)
				{
					writer.Write(Data2[i, j]);
				}
			}
			
		}
	}
	

}
