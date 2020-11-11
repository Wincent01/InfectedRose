using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes the type of primitives stored in a mesh object.
	///         
	/// </summary>
	public enum MeshPrimitiveType : uint
	{
		/// <summary>
		/// Triangle primitive type.
		/// </summary>
		
		MESH_PRIMITIVE_TRIANGLES = 0,
		/// <summary>
		/// Triangle strip primitive type.
		/// </summary>
		
		MESH_PRIMITIVE_TRISTRIPS = 1,
		/// <summary>
		/// Line strip primitive type.
		/// </summary>
		
		MESH_PRIMITIVE_LINESTRIPS = 2,
		/// <summary>
		/// Quadrilateral primitive type.
		/// </summary>
		
		MESH_PRIMITIVE_QUADS = 3,
		/// <summary>
		/// Point primitive type.
		/// </summary>
		
		MESH_PRIMITIVE_POINTS = 4,
	}
	

}
