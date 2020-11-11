using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Used to store skin weights in NiTriShapeSkinController.
	///         
	/// </summary>
	public struct OldSkinData : IConstruct
	{
		/// <summary>
		/// The amount that this bone affects the vertex.
		/// </summary>
		public float VertexWeight { get; set; } 
		
		/// <summary>
		/// The index of the vertex that this weight applies to.
		/// </summary>
		public ushort VertexIndex { get; set; } 
		
		/// <summary>
		/// Unknown.  Perhaps some sort of offset?
		/// </summary>
		public Vector3 UnknownVector { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			VertexWeight = reader.Read<float>();
			
			VertexIndex = reader.Read<ushort>();
			
			UnknownVector = new Vector3();
			UnknownVector.Deserialize(reader);
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(VertexWeight);
			
			writer.Write(VertexIndex);
			
			writer.Write(UnknownVector);
			
		}
	}
	

}
