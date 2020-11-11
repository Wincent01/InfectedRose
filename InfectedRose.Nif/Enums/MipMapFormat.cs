using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing how mipmaps are handled in a texture.
	///         
	/// </summary>
	public enum MipMapFormat : uint
	{
		/// <summary>
		/// Texture does not use mip maps.
		/// </summary>
		
		MIP_FMT_NO = 0,
		/// <summary>
		/// Texture uses mip maps.
		/// </summary>
		
		MIP_FMT_YES = 1,
		/// <summary>
		/// Use default setting.
		/// </summary>
		
		MIP_FMT_DEFAULT = 2,
	}
	

}
