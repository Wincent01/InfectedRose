using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum PropagationMode : uint
	{
		/// <summary>
		/// On Success
		/// </summary>
		
		PROPAGATE_ON_SUCCESS = 0,
		/// <summary>
		/// On Failure
		/// </summary>
		
		PROPAGATE_ON_FAILURE = 1,
		/// <summary>
		/// Always
		/// </summary>
		
		PROPAGATE_ALWAYS = 2,
		/// <summary>
		/// Never
		/// </summary>
		
		PROPAGATE_NEVER = 3,
	}
	

}
