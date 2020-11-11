using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Used by NiPoint3InterpControllers to select which type of color in the controlled object that will be animated.
	///         
	/// </summary>
	public enum TargetColor : ushort
	{
		/// <summary>
		/// Control the ambient color.
		/// </summary>
		
		TC_AMBIENT = 0,
		/// <summary>
		/// Control the diffuse color.
		/// </summary>
		
		TC_DIFFUSE = 1,
		/// <summary>
		/// Control the specular color.
		/// </summary>
		
		TC_SPECULAR = 2,
		/// <summary>
		/// Control the self illumination color.
		/// </summary>
		
		TC_SELF_ILLUM = 3,
	}
	

}
