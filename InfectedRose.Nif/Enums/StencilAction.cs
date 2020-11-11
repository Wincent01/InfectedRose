using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This enum defines the various actions used in conjunction with the stencil buffer.
	///         For a detailed description of the individual options please refer to the OpenGL docs.
	///         
	/// </summary>
	public enum StencilAction : uint
	{
		/// <summary>
		/// 
		/// </summary>
		
		ACTION_KEEP = 0,
		/// <summary>
		/// 
		/// </summary>
		
		ACTION_ZERO = 1,
		/// <summary>
		/// 
		/// </summary>
		
		ACTION_REPLACE = 2,
		/// <summary>
		/// 
		/// </summary>
		
		ACTION_INCREMENT = 3,
		/// <summary>
		/// 
		/// </summary>
		
		ACTION_DECREMENT = 4,
		/// <summary>
		/// 
		/// </summary>
		
		ACTION_INVERT = 5,
	}
	

}
