using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The type of animation interpolation (blending) that will be used on the associated key frames.
	///         
	/// </summary>
	public enum KeyType : uint
	{
		/// <summary>
		/// Use linear interpolation.
		/// </summary>
		
		LINEAR_KEY = 1,
		/// <summary>
		/// Use quadratic interpolation.  Forward and back tangents will be stored.
		/// </summary>
		
		QUADRATIC_KEY = 2,
		/// <summary>
		/// Use Tension Bias Continuity interpolation.  Tension, bias, and continuity will be stored.
		/// </summary>
		
		TBC_KEY = 3,
		/// <summary>
		/// For use only with rotation data.  Separate X, Y, and Z keys will be stored instead of using quaternions.
		/// </summary>
		
		XYZ_ROTATION_KEY = 4,
		/// <summary>
		/// Step function. Used for visibility keys in NiBoolData.
		/// </summary>
		
		CONST_KEY = 5,
	}
	

}
