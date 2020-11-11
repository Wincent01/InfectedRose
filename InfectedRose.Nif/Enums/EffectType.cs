using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The type of information that's store in a texture used by a NiTextureEffect.
	///         
	/// </summary>
	public enum EffectType : uint
	{
		/// <summary>
		/// Apply a projected light texture.
		/// </summary>
		
		EFFECT_PROJECTED_LIGHT = 0,
		/// <summary>
		/// Apply a projected shaddow texture.
		/// </summary>
		
		EFFECT_PROJECTED_SHADOW = 1,
		/// <summary>
		/// Apply an environment map texture.
		/// </summary>
		
		EFFECT_ENVIRONMENT_MAP = 2,
		/// <summary>
		/// Apply a fog map texture.
		/// </summary>
		
		EFFECT_FOG_MAP = 3,
	}
	

}
