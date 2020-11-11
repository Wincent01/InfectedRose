using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Two dimensional screen elements.
	///         
	/// </summary>
	public class NiScreenElementsData : NiTriShapeData
	{
		/// <summary>
		/// Maximum number of polygons?
		/// </summary>
		public ushort MaxPolygons { get; set; } 
		
		/// <summary>
		/// Polygons
		/// </summary>
		public Polygon[] Polygons { get; set; } 
		
		/// <summary>
		/// Polygon Indices
		/// </summary>
		public ushort[] PolygonIndices { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public ushort UnknownUShort1 { get; set; } 
		
		/// <summary>
		/// Number of Polygons actually in use
		/// </summary>
		public ushort NumPolygons { get; set; } 
		
		/// <summary>
		/// Number of in-use vertices
		/// </summary>
		public ushort UsedVertices { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public ushort UnknownUShort2 { get; set; } 
		
		/// <summary>
		/// Number of in-use triangles
		/// </summary>
		public ushort UsedTrianglePoints { get; set; } 
		
		/// <summary>
		/// Maximum number of faces
		/// </summary>
		public ushort UnknownUShort3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			MaxPolygons = reader.Read<ushort>();
			
			Polygons = new Polygon[MaxPolygons];
			for (var i = 0; i < MaxPolygons; i++)
			{
				var value = new Polygon();
				value.Deserialize(reader);
				Polygons[i] = value;
			}
			
			PolygonIndices = new ushort[MaxPolygons];
			for (var i = 0; i < MaxPolygons; i++)
			{
				PolygonIndices[i] = reader.Read<ushort>();
			}
			
			UnknownUShort1 = reader.Read<ushort>();
			
			NumPolygons = reader.Read<ushort>();
			
			UsedVertices = reader.Read<ushort>();
			
			UnknownUShort2 = reader.Read<ushort>();
			
			UsedTrianglePoints = reader.Read<ushort>();
			
			UnknownUShort3 = reader.Read<ushort>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(MaxPolygons);
			
			for (var i = 0; i < MaxPolygons; i++)
			{
				writer.Write(Polygons[i]);
			}
			
			for (var i = 0; i < MaxPolygons; i++)
			{
				writer.Write(PolygonIndices[i]);
			}
			
			writer.Write(UnknownUShort1);
			
			writer.Write(NumPolygons);
			
			writer.Write(UsedVertices);
			
			writer.Write(UnknownUShort2);
			
			writer.Write(UsedTrianglePoints);
			
			writer.Write(UnknownUShort3);
			
		}
	}
	

}
