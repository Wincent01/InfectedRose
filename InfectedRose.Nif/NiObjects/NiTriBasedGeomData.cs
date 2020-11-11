using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes a mesh, built from triangles.
	///         
	/// </summary>
	public abstract class NiTriBasedGeomData : NiGeometryData
	{
		/// <summary>
		/// Number of triangles.
		/// </summary>
		public ushort NumTriangles { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumTriangles = reader.Read<ushort>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumTriangles);
			
		}
	}
	

}
