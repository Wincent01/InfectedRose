using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A weighted vertex.
	///         
	/// </summary>
	public struct SkinWeight : IConstruct
	{
		/// <summary>
		/// The vertex index, in the mesh.
		/// </summary>
		public ushort Index { get; set; } 
		
		/// <summary>
		/// The vertex weight - between 0.0 and 1.0
		/// </summary>
		public float Weight { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Index = reader.Read<ushort>();
			
			Weight = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Index);
			
			writer.Write(Weight);
			
		}
	}
	

}
