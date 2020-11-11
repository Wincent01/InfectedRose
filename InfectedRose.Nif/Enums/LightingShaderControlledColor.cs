using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing which color in BSLightingShaderProperty to animate.
	///         
	/// </summary>
	public enum LightingShaderControlledColor : uint
	{
		/// <summary>
		/// Specular Color.
		/// </summary>
		
		SpecularColor = 0,
		/// <summary>
		/// Emissive Color.
		/// </summary>
		
		EmissiveColor = 1,
	}
	

}
