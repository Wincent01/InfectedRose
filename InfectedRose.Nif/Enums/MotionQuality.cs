using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The motion type. Determines quality of motion?
	///         
	/// </summary>
	public enum MotionQuality : byte
	{
		/// <summary>
		/// Automatically assigned to MO_QUAL_FIXED, MO_QUAL_KEYFRAMED or MO_QUAL_DEBRIS
		/// </summary>
		
		MO_QUAL_INVALID = 0,
		/// <summary>
		/// Use this for fixed bodies. 
		/// </summary>
		
		MO_QUAL_FIXED = 1,
		/// <summary>
		/// Use this for moving objects with infinite mass.
		/// </summary>
		
		MO_QUAL_KEYFRAMED = 2,
		/// <summary>
		/// Use this for all your debris objects
		/// </summary>
		
		MO_QUAL_DEBRIS = 3,
		/// <summary>
		/// Use this for moving bodies, which should not leave the world.
		/// </summary>
		
		MO_QUAL_MOVING = 4,
		/// <summary>
		/// Use this for all objects, which you cannot afford to tunnel through the world at all
		/// </summary>
		
		MO_QUAL_CRITICAL = 5,
		/// <summary>
		/// Use this for very fast objects 
		/// </summary>
		
		MO_QUAL_BULLET = 6,
		/// <summary>
		/// For user.
		/// </summary>
		
		MO_QUAL_USER = 7,
		/// <summary>
		/// Use this for rigid body character controllers
		/// </summary>
		
		MO_QUAL_CHARACTER = 8,
		/// <summary>
		/// 
		///             Use this for moving objects with infinite mass which should report contact points and Toi-collisions against all other bodies, including other fixed and keyframed bodies.
		///         
		/// </summary>
		
		MO_QUAL_KEYFRAMED_REPORT = 9,
	}
	

}
