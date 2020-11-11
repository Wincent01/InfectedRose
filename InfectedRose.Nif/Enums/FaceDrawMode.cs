using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This enum lists the different face culling options.
	///         
	/// </summary>
	public enum FaceDrawMode : uint
	{
		/// <summary>
		/// use application defaults?
		/// </summary>
		
		DRAW_CCW_OR_BOTH = 0,
		/// <summary>
		/// Draw counter clock wise faces, cull clock wise faces. This is the default for most (all?) Nif Games so far.
		/// </summary>
		
		DRAW_CCW = 1,
		/// <summary>
		/// Draw clock wise faces, cull counter clock wise faces. This will flip all the faces.
		/// </summary>
		
		DRAW_CW = 2,
		/// <summary>
		/// Draw double sided faces.
		/// </summary>
		
		DRAW_BOTH = 3,
	}
	

}
