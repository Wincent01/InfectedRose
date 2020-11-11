using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Specifies the availiable texture clamp modes.  That is, the behavior of pixels outside the range of the texture.
	///         
	/// </summary>
	public enum TexClampMode : uint
	{
		/// <summary>
		/// Clamp in both directions.
		/// </summary>
		
		CLAMP_S_CLAMP_T = 0,
		/// <summary>
		/// Clamp in the S(U) direction but wrap in the T(V) direction.
		/// </summary>
		
		CLAMP_S_WRAP_T = 1,
		/// <summary>
		/// Wrap in the S(U) direction but clamp in the T(V) direction.
		/// </summary>
		
		WRAP_S_CLAMP_T = 2,
		/// <summary>
		/// Wrap in both directions.
		/// </summary>
		
		WRAP_S_WRAP_T = 3,
	}
	

}
