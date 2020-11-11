using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This enum contains the options for doing stencil buffer tests.
	///         
	/// </summary>
	public enum StencilCompareMode : uint
	{
		/// <summary>
		/// Test will allways return false. Nothing is drawn at all.
		/// </summary>
		
		TEST_NEVER = 0,
		/// <summary>
		/// The test will only succeed if the pixel is nearer than the previous pixel.
		/// </summary>
		
		TEST_LESS = 1,
		/// <summary>
		/// Test will only succeed if the z value of the pixel to be drawn is equal to the value of the previous drawn pixel.
		/// </summary>
		
		TEST_EQUAL = 2,
		/// <summary>
		/// Test will succeed if the z value of the pixel to be drawn is smaller than or equal to the value in the Stencil Buffer.
		/// </summary>
		
		TEST_LESS_EQUAL = 3,
		/// <summary>
		/// Opposite of TEST_LESS.
		/// </summary>
		
		TEST_GREATER = 4,
		/// <summary>
		/// Test will succeed if the z value of the pixel to be drawn is NOT equal to the value of the previously drawn pixel.
		/// </summary>
		
		TEST_NOT_EQUAL = 5,
		/// <summary>
		/// Opposite of TEST_LESS_EQUAL.
		/// </summary>
		
		TEST_GREATER_EQUAL = 6,
		/// <summary>
		/// Test will allways succeed. The Stencil Buffer value is ignored.
		/// </summary>
		
		TEST_ALWAYS = 7,
	}
	

}
