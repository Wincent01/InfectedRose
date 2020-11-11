using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An unsigned 32-bit integer, describing which float variable in BSEffectShaderProperty to animate.
	///         
	/// </summary>
	public enum EffectShaderControlledVariable : uint
	{
		/// <summary>
		/// EmissiveMultiple.
		/// </summary>
		
		EmissiveMultiple = 0,
		/// <summary>
		/// Falloff Start Angle (degrees).
		/// </summary>
		
		FalloffStartAngledegrees = 1,
		/// <summary>
		/// Falloff Stop Angle (degrees).
		/// </summary>
		
		FalloffStopAngledegrees = 2,
		/// <summary>
		/// Falloff Start Opacity.
		/// </summary>
		
		FalloffStartOpacity = 3,
		/// <summary>
		/// Falloff Stop Opacity.
		/// </summary>
		
		FalloffStopOpacity = 4,
		/// <summary>
		/// Alpha Transparency (Emissive alpha?).
		/// </summary>
		
		AlphaTransparencyEmissivealpha = 5,
		/// <summary>
		/// U Offset.
		/// </summary>
		
		UOffset = 6,
		/// <summary>
		/// U Scale.
		/// </summary>
		
		UScale = 7,
		/// <summary>
		/// V Offset.
		/// </summary>
		
		VOffset = 8,
		/// <summary>
		/// V Scale.
		/// </summary>
		
		VScale = 9,
	}
	

}
