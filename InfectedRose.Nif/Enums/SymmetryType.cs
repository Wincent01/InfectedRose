using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines symetry type used by NiPSysBombModifier.
	///         
	/// </summary>
	public enum SymmetryType : uint
	{
		/// <summary>
		/// Spherical Symmetry.
		/// </summary>
		
		SPHERICAL_SYMMETRY = 0,
		/// <summary>
		/// Cylindrical Symmetry.
		/// </summary>
		
		CYLINDRICAL_SYMMETRY = 1,
		/// <summary>
		/// Planar Symmetry.
		/// </summary>
		
		PLANAR_SYMMETRY = 2,
	}
	

}
