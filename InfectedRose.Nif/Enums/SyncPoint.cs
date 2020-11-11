using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Specifies the time when an application must syncronize for some reason.
	///         
	/// </summary>
	public enum SyncPoint : ushort
	{
		/// <summary>
		/// Value used when no specific sync point is desired.
		/// </summary>
		
		SYNC_ANY = 0x8000,
		/// <summary>
		/// Synchronize when an object is updated.
		/// </summary>
		
		SYNC_UPDATE = 0x8010,
		/// <summary>
		/// Synchronize when an entire scene graph has been updated.
		/// </summary>
		
		SYNC_POST_UPDATE = 0x8020,
		/// <summary>
		/// Synchronize when an object is determined to be potentially visible.
		/// </summary>
		
		SYNC_VISIBLE = 0x8030,
		/// <summary>
		/// Synchronize when an object is rendered.
		/// </summary>
		
		SYNC_RENDER = 0x8040,
		/// <summary>
		/// Synchronize when a physics simulation step is about to begin.
		/// </summary>
		
		SYNC_PHYSICS_SIMULATE = 0x8050,
		/// <summary>
		/// Synchronize when a physics simulation step has produced results.
		/// </summary>
		
		SYNC_PHYSICS_COMPLETED = 0x8060,
		/// <summary>
		/// Syncronize after all data necessary to calculate reflections is ready.
		/// </summary>
		
		SYNC_REFLECTIONS = 0x8070,
	}
	

}
