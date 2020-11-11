using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A list of possible solver deactivation settings. This value defines how the
	///         solver deactivates objects. The solver works on a per object basis.
	///         Note: Solver deactivation does not save CPU, but reduces creeping of
	///         movable objects in a pile quite dramatically.
	///         
	/// </summary>
	public enum SolverDeactivation : byte
	{
		/// <summary>
		/// Invalid
		/// </summary>
		
		SOLVER_DEACTIVATION_INVALID = 0,
		/// <summary>
		/// No solver deactivation
		/// </summary>
		
		SOLVER_DEACTIVATION_OFF = 1,
		/// <summary>
		/// Very conservative deactivation, typically no visible artifacts.
		/// </summary>
		
		SOLVER_DEACTIVATION_LOW = 2,
		/// <summary>
		/// Normal deactivation, no serious visible artifacts in most cases
		/// </summary>
		
		SOLVER_DEACTIVATION_MEDIUM = 3,
		/// <summary>
		/// Fast deactivation, visible artifacts
		/// </summary>
		
		SOLVER_DEACTIVATION_HIGH = 4,
		/// <summary>
		/// Very fast deactivation, visible artifacts
		/// </summary>
		
		SOLVER_DEACTIVATION_MAX = 5,
	}
	

}
