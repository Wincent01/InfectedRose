using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Sets how objects are to be cloned.
	///         
	/// </summary>
	public enum CloningBehavior : uint
	{
		/// <summary>
		/// Share this object pointer with the newly cloned scene.
		/// </summary>
		
		CLONING_SHARE = 0,
		/// <summary>
		/// Create an exact duplicate of this object for use with the newly cloned scene.
		/// </summary>
		
		CLONING_COPY = 1,
		/// <summary>
		/// Create a copy of this object for use with the newly cloned stream, leaving some of the data to be written later.
		/// </summary>
		
		CLONING_BLANK_COPY = 2,
	}
	

}
