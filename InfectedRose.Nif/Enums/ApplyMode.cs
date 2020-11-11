using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing the apply mode of a texture.
	///         
	/// </summary>
	public enum ApplyMode : uint
	{
		/// <summary>
		/// Replaces existing color
		/// </summary>
		
		APPLY_REPLACE = 0,
		/// <summary>
		/// For placing images on the object like stickers.
		/// </summary>
		
		APPLY_DECAL = 1,
		/// <summary>
		/// Modulates existing color. (Default)
		/// </summary>
		
		APPLY_MODULATE = 2,
		/// <summary>
		/// PS2 Only.  Function Unknown.
		/// </summary>
		
		APPLY_HILIGHT = 3,
		/// <summary>
		/// Parallax Flag in some Oblivion meshes.
		/// </summary>
		
		APPLY_HILIGHT2 = 4,
	}
	

}
