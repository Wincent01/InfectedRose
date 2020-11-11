using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The type of texture.
	///         
	/// </summary>
	public enum TexType : uint
	{
		/// <summary>
		/// The basic texture used by most meshes.
		/// </summary>
		
		BASE_MAP = 0,
		/// <summary>
		/// Used to darken the model with false lighting.
		/// </summary>
		
		DARK_MAP = 1,
		/// <summary>
		/// Combined with base map for added detail.  Usually tiled over the mesh many times for close-up view.
		/// </summary>
		
		DETAIL_MAP = 2,
		/// <summary>
		/// Allows the specularity (glossyness) of an object to differ across its surface.
		/// </summary>
		
		GLOSS_MAP = 3,
		/// <summary>
		/// Creates a glowing effect.  Basically an incandescence map.
		/// </summary>
		
		GLOW_MAP = 4,
		/// <summary>
		/// Used to make the object appear to have more detail than it really does.
		/// </summary>
		
		BUMP_MAP = 5,
		/// <summary>
		/// Used to make the object appear to have more detail than it really does.
		/// </summary>
		
		NORMAL_MAP = 6,
		/// <summary>
		/// Unknown map.
		/// </summary>
		
		UNKNOWN2_MAP = 7,
		/// <summary>
		/// For placing images on the object like stickers.
		/// </summary>
		
		DECAL_0_MAP = 8,
		/// <summary>
		/// For placing images on the object like stickers.
		/// </summary>
		
		DECAL_1_MAP = 9,
		/// <summary>
		/// For placing images on the object like stickers.
		/// </summary>
		
		DECAL_2_MAP = 10,
		/// <summary>
		/// For placing images on the object like stickers.
		/// </summary>
		
		DECAL_3_MAP = 11,
	}
	

}
