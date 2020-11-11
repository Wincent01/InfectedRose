using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Controls which parts of the mesh that the particles are emitted from.
	///         
	/// </summary>
	public enum EmitFrom : uint
	{
		/// <summary>
		/// Emit particles from the vertices of the mesh.
		/// </summary>
		
		EMIT_FROM_VERTICES = 0,
		/// <summary>
		/// Emit particles from the center of the faces of the mesh.
		/// </summary>
		
		EMIT_FROM_FACE_CENTER = 1,
		/// <summary>
		/// Emit particles from the center of the edges of the mesh.
		/// </summary>
		
		EMIT_FROM_EDGE_CENTER = 2,
		/// <summary>
		/// Perhaps randomly emit particles from anywhere on the faces of the mesh?
		/// </summary>
		
		EMIT_FROM_FACE_SURFACE = 3,
		/// <summary>
		/// Perhaps randomly emit particles from anywhere on the edges of the mesh?
		/// </summary>
		
		EMIT_FROM_EDGE_SURFACE = 4,
	}
	

}
