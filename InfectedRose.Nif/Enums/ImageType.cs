using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines how the raw image data is stored in NiRawImageData.
	///         
	/// </summary>
	public enum ImageType : uint
	{
		/// <summary>
		/// Colors store red, blue, and green components.
		/// </summary>
		
		RGB = 1,
		/// <summary>
		/// Colors store red, blue, green, and alpha components.
		/// </summary>
		
		RGBA = 2,
	}
	

}
