using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This enum contains the options for doing z buffer tests.
	///         
	/// </summary>
	public enum ZCompareMode : uint
	{
		/// <summary>
		/// Test will allways succeed. The Z Buffer value is ignored.
		/// </summary>
		
		ZCOMP_ALWAYS = 0,
		/// <summary>
		/// The test will only succeed if the pixel is nearer than the previous pixel.
		/// </summary>
		
		ZCOMP_LESS = 1,
		/// <summary>
		/// Test will only succeed if the z value of the pixel to be drawn is equal to the value of the previous drawn pixel.
		/// </summary>
		
		ZCOMP_EQUAL = 2,
		/// <summary>
		/// Test will succeed if the z value of the pixel to be drawn is smaller than or equal to the value in the Z Buffer.
		/// </summary>
		
		ZCOMP_LESS_EQUAL = 3,
		/// <summary>
		/// Opposite of TEST_LESS.
		/// </summary>
		
		ZCOMP_GREATER = 4,
		/// <summary>
		/// Test will succeed if the z value of the pixel to be drawn is NOT equal to the value of the previously drawn pixel.
		/// </summary>
		
		ZCOMP_NOT_EQUAL = 5,
		/// <summary>
		/// Opposite of TEST_LESS_EQUAL.
		/// </summary>
		
		ZCOMP_GREATER_EQUAL = 6,
		/// <summary>
		/// Test will allways return false. Nothing is drawn at all.
		/// </summary>
		
		ZCOMP_NEVER = 7,
	}
	

}
