using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing how vertex colors influence lighting.
	///         
	/// </summary>
	public enum LightMode : uint
	{
		/// <summary>
		/// Emissive.
		/// </summary>
		
		LIGHT_MODE_EMISSIVE = 0,
		/// <summary>
		/// Emissive + Ambient + Diffuse. (Default)
		/// </summary>
		
		LIGHT_MODE_EMI_AMB_DIF = 1,
	}
	

}
