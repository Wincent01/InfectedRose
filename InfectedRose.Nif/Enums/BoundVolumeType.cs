using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum BoundVolumeType : uint
	{
		/// <summary>
		/// Default
		/// </summary>
		
		BASE_BV = 0xffffffff,
		/// <summary>
		/// Sphere
		/// </summary>
		
		SPHERE_BV = 0,
		/// <summary>
		/// Box
		/// </summary>
		
		BOX_BV = 1,
		/// <summary>
		/// Capsule
		/// </summary>
		
		CAPSULE_BV = 2,
		/// <summary>
		/// Union
		/// </summary>
		
		UNION_BV = 4,
		/// <summary>
		/// Half Space
		/// </summary>
		
		HALFSPACE_BV = 5,
	}
	

}
