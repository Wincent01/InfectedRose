using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum DeactivatorType : byte
	{
		/// <summary>
		/// Invalid
		/// </summary>
		
		DEACTIVATOR_INVALID = 0,
		/// <summary>
		/// This will force the rigid body to never deactivate.
		/// </summary>
		
		DEACTIVATOR_NEVER = 1,
		/// <summary>
		/// Tells Havok to use a spatial deactivation scheme. This makes use of high and low frequencies of positional motion to determine when deactivation should occur.
		/// </summary>
		
		DEACTIVATOR_SPATIAL = 2,
	}
	

}
