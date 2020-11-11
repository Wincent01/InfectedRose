using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing the color depth of a texture.
	///         
	/// </summary>
	public enum PixelLayout : uint
	{
		/// <summary>
		/// Texture is in 8-bit paletized format.
		/// </summary>
		
		PIX_LAY_PALETTISED = 0,
		/// <summary>
		/// Texture is in 16-bit high color format.
		/// </summary>
		
		PIX_LAY_HIGH_COLOR_16 = 1,
		/// <summary>
		/// Texture is in 32-bit true color format.
		/// </summary>
		
		PIX_LAY_TRUE_COLOR_32 = 2,
		/// <summary>
		/// Texture is compressed.
		/// </summary>
		
		PIX_LAY_COMPRESSED = 3,
		/// <summary>
		/// Texture is a grayscale bump map.
		/// </summary>
		
		PIX_LAY_BUMPMAP = 4,
		/// <summary>
		/// Texture is in 4-bit paletized format.
		/// </summary>
		
		PIX_LAY_PALETTISED_4 = 5,
		/// <summary>
		/// Use default setting.
		/// </summary>
		
		PIX_LAY_DEFAULT = 6,
	}
	

}
