using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines how a NiTextureTransformController animates the UV coordinates.
	///         
	/// </summary>
	public enum TexTransform : uint
	{
		/// <summary>
		/// Means this controller moves the U texture cooridnates.
		/// </summary>
		
		TT_TRANSLATE_U = 0,
		/// <summary>
		/// Means this controller moves the V texture cooridnates.
		/// </summary>
		
		TT_TRANSLATE_V = 1,
		/// <summary>
		/// Means this controller roates the UV texture cooridnates.
		/// </summary>
		
		TT_ROTATE = 2,
		/// <summary>
		/// Means this controller scales the U texture cooridnates.
		/// </summary>
		
		TT_SCALE_U = 3,
		/// <summary>
		/// Means this controller scales the V texture cooridnates.
		/// </summary>
		
		TT_SCALE_V = 4,
	}
	

}
