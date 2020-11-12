using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Two dimensional screen elements.
	///         
	/// </summary>
	public class Polygon : IConstruct
	{
		/// <summary>
		/// Number of vertices in this polygon
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// Vertex Offset
		/// </summary>
		public ushort VertexOffset { get; set; } 
		
		/// <summary>
		/// Number of faces in this polygon
		/// </summary>
		public ushort NumTriangles { get; set; } 
		
		/// <summary>
		/// Triangle offset in shape
		/// </summary>
		public ushort TriangleOffset { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumVertices = reader.Read<ushort>();
			
			VertexOffset = reader.Read<ushort>();
			
			NumTriangles = reader.Read<ushort>();
			
			TriangleOffset = reader.Read<ushort>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumVertices);
			
			writer.Write(VertexOffset);
			
			writer.Write(NumTriangles);
			
			writer.Write(TriangleOffset);
			
		}
	}
	

}
