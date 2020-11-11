using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Specifies the availiable texture filter modes.  That is, the way pixels within a texture are blended together when textures are displayed on the screen at a size other than their original dimentions.
	///         
	/// </summary>
	public enum TexFilterMode : uint
	{
		/// <summary>
		/// Simply uses the nearest pixel.  Very grainy.
		/// </summary>
		
		FILTER_NEAREST = 0,
		/// <summary>
		/// Uses bilinear filtering.
		/// </summary>
		
		FILTER_BILERP = 1,
		/// <summary>
		/// Uses trilinear filtering.
		/// </summary>
		
		FILTER_TRILERP = 2,
		/// <summary>
		/// Uses the nearest pixel from the mipmap that is closest to the display size.
		/// </summary>
		
		FILTER_NEAREST_MIPNEAREST = 3,
		/// <summary>
		/// Blends the two mipmaps closest to the display size linearly, and then uses the nearest pixel from the result.
		/// </summary>
		
		FILTER_NEAREST_MIPLERP = 4,
		/// <summary>
		/// Uses the closest mipmap to the display size and then uses bilinear filtering on the pixels.
		/// </summary>
		
		FILTER_BILERP_MIPNEAREST = 5,
	}
	

}
