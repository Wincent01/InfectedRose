using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines the way the billboard will react to the camera.
	///         
	/// </summary>
	public enum BillboardMode : ushort
	{
		/// <summary>
		/// The billboard will always face the camera.
		/// </summary>
		
		ALWAYS_FACE_CAMERA = 0,
		/// <summary>
		/// The billboard will only rotate around the up axis.
		/// </summary>
		
		ROTATE_ABOUT_UP = 1,
		/// <summary>
		/// Rigid Face Camera.
		/// </summary>
		
		RIGID_FACE_CAMERA = 2,
		/// <summary>
		/// Always Face Center.
		/// </summary>
		
		ALWAYS_FACE_CENTER = 3,
		/// <summary>
		/// Rigid Face Center.
		/// </summary>
		
		RIGID_FACE_CENTER = 4,
		/// <summary>
		/// The billboard will only rotate around the up axis (same as ROTATE_ABOUT_UP?).
		/// </summary>
		
		ROTATE_ABOUT_UP2 = 9,
	}
	

}
