using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// 		Animation type used on this position. This specifies the function of this position.
	/// 		
	/// </summary>
	public enum AnimationType : ushort
	{
		/// <summary>
		/// Actor use sit animation.
		/// </summary>
		
		Sit = 1,
		/// <summary>
		/// Actor use sleep animation.
		/// </summary>
		
		Sleep = 2,
		/// <summary>
		/// Used for lean animations?
		/// </summary>
		
		Lean = 4,
	}
	

}
