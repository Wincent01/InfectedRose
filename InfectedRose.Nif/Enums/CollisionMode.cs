using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum CollisionMode : uint
	{
		/// <summary>
		/// Use Bounding Box
		/// </summary>
		
		CM_USE_OBB = 0,
		/// <summary>
		/// Use Triangles
		/// </summary>
		
		CM_USE_TRI = 1,
		/// <summary>
		/// Use Alternate Bounding Volumes
		/// </summary>
		
		CM_USE_ABV = 2,
		/// <summary>
		/// No Test
		/// </summary>
		
		CM_NOTEST = 3,
		/// <summary>
		/// Use NiBound
		/// </summary>
		
		CM_USE_NIBOUND = 4,
	}
	

}
