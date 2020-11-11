using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Array of Vectors for Decal placement in BSDecalPlacementVectorExtraData.
	///         
	/// </summary>
	public struct DecalVectorArray : IConstruct
	{
		/// <summary>
		/// Number of sets
		/// </summary>
		public short NumVectors { get; set; } 
		
		/// <summary>
		/// Vector XYZ coords
		/// </summary>
		public Vector3[] Points { get; set; } 
		
		/// <summary>
		/// Vector Normals
		/// </summary>
		public Vector3[] Normals { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumVectors = reader.Read<short>();
			
			Points = new Vector3[NumVectors];
			for (var i = 0; i < NumVectors; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Points[i] = value;
			}
			
			Normals = new Vector3[NumVectors];
			for (var i = 0; i < NumVectors; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Normals[i] = value;
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumVectors);
			
			for (var i = 0; i < NumVectors; i++)
			{
				writer.Write(Points[i]);
			}
			
			for (var i = 0; i < NumVectors; i++)
			{
				writer.Write(Normals[i]);
			}
			
		}
	}
	

}
