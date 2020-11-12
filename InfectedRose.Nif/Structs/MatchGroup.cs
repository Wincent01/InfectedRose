using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Group of vertex indices of vertices that match.
	///         
	/// </summary>
	public class MatchGroup : IConstruct
	{
		/// <summary>
		/// Number of vertices in this group.
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// The vertex indices.
		/// </summary>
		public ushort[] VertexIndices { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumVertices = reader.Read<ushort>();
			
			VertexIndices = new ushort[NumVertices];
			for (var i = 0; i < NumVertices; i++)
			{
				VertexIndices[i] = reader.Read<ushort>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumVertices);
			
			for (var i = 0; i < NumVertices; i++)
			{
				writer.Write(VertexIndices[i]);
			}
			
		}
	}
	

}
