using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines decay function.  Used by NiPSysBombModifier.
	///         
	/// </summary>
	public enum DecayType : uint
	{
		/// <summary>
		/// No decay.
		/// </summary>
		
		DECAY_NONE = 0,
		/// <summary>
		/// Linear decay.
		/// </summary>
		
		DECAY_LINEAR = 1,
		/// <summary>
		/// Exponential decay.
		/// </summary>
		
		DECAY_EXPONENTIAL = 2,
	}
	

}
