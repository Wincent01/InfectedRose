using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines how a data stream is used?
	///         
	/// </summary>
	public enum DataStreamUsage : uint
	{
		/// <summary>
		/// 
		/// </summary>
		
		USAGE_VERTEX_INDEX = 0,
		/// <summary>
		/// 
		/// </summary>
		
		USAGE_VERTEX = 1,
		/// <summary>
		/// 
		/// </summary>
		
		USAGE_SHADER_CONSTANT = 2,
		/// <summary>
		/// 
		/// </summary>
		
		USAGE_USER = 3,
	}
	

}
