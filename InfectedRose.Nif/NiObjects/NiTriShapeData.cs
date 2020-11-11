using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Holds mesh data using a list of singular triangles.
	///         
	/// </summary>
	public class NiTriShapeData : NiTriBasedGeomData
	{
		/// <summary>
		/// Num Triangles times 3.
		/// </summary>
		public uint NumTrianglePoints { get; set; } 
		
		/// <summary>
		/// Do we have triangle data?
		/// </summary>
		public bool HasTriangles { get; set; } 
		
		/// <summary>
		/// Triangle face data.
		/// </summary>
		public Triangle[] Triangles { get; set; } 
		
		/// <summary>
		/// Number of shared normals groups.
		/// </summary>
		public ushort NumMatchGroups { get; set; } 
		
		/// <summary>
		/// The shared normals.
		/// </summary>
		public MatchGroup[] MatchGroups { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumTrianglePoints = reader.Read<uint>();
			
			HasTriangles = reader.Read<byte>() != 0;
			
			if (HasTriangles)
			{
				Triangles = new Triangle[NumTriangles];
				for (var i = 0; i < NumTriangles; i++)
				{
					var value = new Triangle();
					value.Deserialize(reader);
					Triangles[i] = value;
				}
				
			}
			NumMatchGroups = reader.Read<ushort>();
			
			MatchGroups = new MatchGroup[NumMatchGroups];
			for (var i = 0; i < NumMatchGroups; i++)
			{
				var value = new MatchGroup();
				value.Deserialize(reader);
				MatchGroups[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumTrianglePoints);
			
			writer.Write((byte) (HasTriangles ? 1 : 0));
			
			if (HasTriangles)
			{
				for (var i = 0; i < NumTriangles; i++)
				{
					writer.Write(Triangles[i]);
				}
				
			}
			writer.Write(NumMatchGroups);
			
			for (var i = 0; i < NumMatchGroups; i++)
			{
				writer.Write(MatchGroups[i]);
			}
			
		}
	}
	

}
