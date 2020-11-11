using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum ChannelConvention : uint
	{
		/// <summary>
		/// Fixed
		/// </summary>
		
		CC_FIXED = 0,
		/// <summary>
		/// Palettized
		/// </summary>
		
		CC_INDEX = 3,
		/// <summary>
		/// Compressed
		/// </summary>
		
		CC_COMPRESSED = 4,
		/// <summary>
		/// Empty
		/// </summary>
		
		CC_EMPTY = 5,
	}
	

}
