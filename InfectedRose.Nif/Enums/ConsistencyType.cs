using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Used by NiGeometryData to control the volatility of the mesh.  While they appear to be flags they behave as an enum.
	///         
	/// </summary>
	public enum ConsistencyType : ushort
	{
		/// <summary>
		/// Mutable Mesh
		/// </summary>
		
		CT_MUTABLE = 0x0000,
		/// <summary>
		/// Static Mesh
		/// </summary>
		
		CT_STATIC = 0x4000,
		/// <summary>
		/// Volatile Mesh
		/// </summary>
		
		CT_VOLATILE = 0x8000,
	}
	

}
