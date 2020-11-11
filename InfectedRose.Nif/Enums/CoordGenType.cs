using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines the way that UV texture coordinates are generated.
	///         
	/// </summary>
	public enum CoordGenType : uint
	{
		/// <summary>
		/// Use plannar mapping.
		/// </summary>
		
		CG_WORLD_PARALLEL = 0,
		/// <summary>
		/// Use perspective mapping.
		/// </summary>
		
		CG_WORLD_PERSPECTIVE = 1,
		/// <summary>
		/// Use spherical mapping.
		/// </summary>
		
		CG_SPHERE_MAP = 2,
		/// <summary>
		/// Use specular cube mapping.
		/// </summary>
		
		CG_SPECULAR_CUBE_MAP = 3,
		/// <summary>
		/// Use Diffuse cube mapping.
		/// </summary>
		
		CG_DIFFUSE_CUBE_MAP = 4,
	}
	

}
