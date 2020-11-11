using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The animation cyle behavior.
	///         
	/// </summary>
	public enum CycleType : uint
	{
		/// <summary>
		/// Loop
		/// </summary>
		
		CYCLE_LOOP = 0,
		/// <summary>
		/// Reverse
		/// </summary>
		
		CYCLE_REVERSE = 1,
		/// <summary>
		/// Clamp
		/// </summary>
		
		CYCLE_CLAMP = 2,
	}
	

}
