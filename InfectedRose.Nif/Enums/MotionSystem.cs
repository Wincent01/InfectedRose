using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The motion system. 4 (Box) is used for everything movable. 7 (Keyframed) is used on statics and animated stuff.
	/// 
	///         
	/// </summary>
	public enum MotionSystem : byte
	{
		/// <summary>
		/// Invalid
		/// </summary>
		
		MO_SYS_INVALID = 0,
		/// <summary>
		/// A fully-simulated, movable rigid body. At construction time the engine checks the input inertia and selects MO_SYS_SPHERE_INERTIA or MO_SYS_BOX_INERTIA as appropriate.
		/// </summary>
		
		MO_SYS_DYNAMIC = 1,
		/// <summary>
		/// Simulation is performed using a sphere inertia tensor.
		/// </summary>
		
		MO_SYS_SPHERE = 2,
		/// <summary>
		/// This is the same as MO_SYS_SPHERE_INERTIA, except that simulation of the rigid body is "softened".
		/// </summary>
		
		MO_SYS_SPHERE_INERTIA = 3,
		/// <summary>
		/// Simulation is performed using a box inertia tensor.
		/// </summary>
		
		MO_SYS_BOX = 4,
		/// <summary>
		/// This is the same as MO_SYS_BOX_INERTIA, except that simulation of the rigid body is "softened".
		/// </summary>
		
		MO_SYS_BOX_STABILIZED = 5,
		/// <summary>
		/// Simulation is not performed as a normal rigid body. The keyframed rigid body has an infinite mass when viewed by the rest of the system. (used for creatures)
		/// </summary>
		
		MO_SYS_KEYFRAMED = 6,
		/// <summary>
		/// This motion type is used for the static elements of a game scene, e.g. the landscape. Faster than MO_SYS_KEYFRAMED at velocity 0. (used for weapons)
		/// </summary>
		
		MO_SYS_FIXED = 7,
		/// <summary>
		/// A box inertia motion which is optimized for thin boxes and has less stability problems
		/// </summary>
		
		MO_SYS_THIN_BOX = 8,
		/// <summary>
		/// A specialized motion used for character controllers
		/// </summary>
		
		MO_SYS_CHARACTER = 9,
	}
	

}
