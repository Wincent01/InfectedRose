using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A byte describing if MOPP Data is organized into chunks (PS3) or not (PC)
	///         
	/// </summary>
	public enum MoppDataBuildType : byte
	{
		/// <summary>
		/// Organized in chunks for PS3.
		/// </summary>
		
		BUILT_WITH_CHUNK_SUBDIVISION = 0,
		/// <summary>
		/// Not organized in chunks for PC. (Default)
		/// </summary>
		
		BUILT_WITHOUT_CHUNK_SUBDIVISION = 1,
		/// <summary>
		/// Build type not set yet.
		/// </summary>
		
		BUILD_NOT_SET = 2,
	}
	

}
