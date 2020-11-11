using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Specifies the pixel format used by the NiPixelData object to store a texture.
	///         
	/// </summary>
	public enum PixelFormat : uint
	{
		/// <summary>
		/// 24-bit color: uses 8 bit to store each red, blue, and green component.
		/// </summary>
		
		PX_FMT_RGB8 = 0,
		/// <summary>
		/// 32-bit color with alpha: uses 8 bits to store each red, blue, green, and alpha component.
		/// </summary>
		
		PX_FMT_RGBA8 = 1,
		/// <summary>
		/// 8-bit palette index: uses 8 bits to store an index into the palette stored in a NiPalette object.
		/// </summary>
		
		PX_FMT_PAL8 = 2,
		/// <summary>
		/// DXT1 compressed texture.
		/// </summary>
		
		PX_FMT_DXT1 = 4,
		/// <summary>
		/// DXT5 compressed texture.
		/// </summary>
		
		PX_FMT_DXT5 = 5,
		/// <summary>
		/// DXT5 compressed texture. It is not clear what the difference is with PX_FMT_DXT5.
		/// </summary>
		
		PX_FMT_DXT5_ALT = 6,
	}
	

}
