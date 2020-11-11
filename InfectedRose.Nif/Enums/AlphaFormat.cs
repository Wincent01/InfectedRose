using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing how transparency is handled in a texture.
	///         
	/// </summary>
	public enum AlphaFormat : uint
	{
		/// <summary>
		/// No alpha blending; the texture is fully opaque.
		/// </summary>
		
		ALPHA_NONE = 0,
		/// <summary>
		/// Texture is either fully transparent or fully opaque.  There are no partially transparent areas.
		/// </summary>
		
		ALPHA_BINARY = 1,
		/// <summary>
		/// Full range of alpha values can be used from fully transparent to fully opaque including all partially transparent values in between.
		/// </summary>
		
		ALPHA_SMOOTH = 2,
		/// <summary>
		/// Use default setting.
		/// </summary>
		
		ALPHA_DEFAULT = 3,
	}
	

}
