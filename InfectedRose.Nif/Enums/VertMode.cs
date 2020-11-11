using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, which describes how to apply vertex colors.
	///         
	/// </summary>
	public enum VertMode : uint
	{
		/// <summary>
		/// Source Ignore.
		/// </summary>
		
		VERT_MODE_SRC_IGNORE = 0,
		/// <summary>
		/// Source Emissive.
		/// </summary>
		
		VERT_MODE_SRC_EMISSIVE = 1,
		/// <summary>
		/// Source Ambient/Diffuse. (Default)
		/// </summary>
		
		VERT_MODE_SRC_AMB_DIF = 2,
	}
	

}
