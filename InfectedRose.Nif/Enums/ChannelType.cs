using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum ChannelType : uint
	{
		/// <summary>
		/// Red
		/// </summary>
		
		CHNL_RED = 0,
		/// <summary>
		/// Green
		/// </summary>
		
		CHNL_GREEN = 1,
		/// <summary>
		/// Blue
		/// </summary>
		
		CHNL_BLUE = 2,
		/// <summary>
		/// Alpha
		/// </summary>
		
		CHNL_ALPHA = 3,
		/// <summary>
		/// Compressed
		/// </summary>
		
		CHNL_COMPRESSED = 4,
		/// <summary>
		/// Index
		/// </summary>
		
		CHNL_INDEX = 16,
		/// <summary>
		/// Empty
		/// </summary>
		
		CHNL_EMPTY = 19,
	}
	

}
