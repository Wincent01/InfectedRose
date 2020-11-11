using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Controls the way the a particle mesh emitter determines the starting speed and direction of the particles that are emitted.
	///         
	/// </summary>
	public enum VelocityType : uint
	{
		/// <summary>
		/// Uses the normals of the meshes to determine staring velocity.
		/// </summary>
		
		VELOCITY_USE_NORMALS = 0,
		/// <summary>
		/// Starts particles with a random velocity.
		/// </summary>
		
		VELOCITY_USE_RANDOM = 1,
		/// <summary>
		/// Uses the emission axis to determine initial particle direction?
		/// </summary>
		
		VELOCITY_USE_DIRECTION = 2,
	}
	

}
