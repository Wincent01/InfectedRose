using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing which float variable in BSLightingShaderProperty to animate.
	///         
	/// </summary>
	public enum LightingShaderControlledVariable : uint
	{
		/// <summary>
		/// Unknown Float 2.
		/// </summary>
		
		UnknownFloat2 = 0,
		/// <summary>
		/// Environment Map Scale.
		/// </summary>
		
		EnvironmentMapScale = 8,
		/// <summary>
		/// Glossiness.
		/// </summary>
		
		Glossiness = 9,
		/// <summary>
		/// Specular Strength.
		/// </summary>
		
		SpecularStrength = 10,
		/// <summary>
		/// Emissive Multiple.
		/// </summary>
		
		EmissiveMultiple = 11,
		/// <summary>
		/// Alpha.
		/// </summary>
		
		Alpha = 12,
		/// <summary>
		/// U Offset.
		/// </summary>
		
		UOffset = 20,
		/// <summary>
		/// U Scale.
		/// </summary>
		
		UScale = 21,
		/// <summary>
		/// V Offset.
		/// </summary>
		
		VOffset = 22,
		/// <summary>
		/// V Scale.
		/// </summary>
		
		VScale = 23,
	}
	

}
