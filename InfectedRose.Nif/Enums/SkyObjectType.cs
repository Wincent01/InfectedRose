using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Skyrim, sets what sky function this object fulfills in BSSkyShaderProperty.
	///         
	/// </summary>
	public enum SkyObjectType : uint
	{
		/// <summary>
		/// BSSM_Sky_Texture
		/// </summary>
		
		BSSM_SKY_TEXTURE = 0,
		/// <summary>
		/// BSSM_Sky_Sunglare
		/// </summary>
		
		BSSM_SKY_SUNGLARE = 1,
		/// <summary>
		/// BSSM_Sky
		/// </summary>
		
		BSSM_SKY = 2,
		/// <summary>
		/// BSSM_Sky_Clouds
		/// </summary>
		
		BSSM_SKY_CLOUDS = 3,
		/// <summary>
		/// BSSM_Sky_Stars
		/// </summary>
		
		BSSM_SKY_STARS = 5,
		/// <summary>
		/// BSSM_Sky_Moon_Stars_Mask
		/// </summary>
		
		BSSM_SKY_MOON_STARS_MASK = 7,
	}
	

}
