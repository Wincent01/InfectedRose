using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public enum EndianType : byte
	{
		/// <summary>
		/// The numbers are stored in big endian format, such as those used by PowerPC Mac processors.
		/// </summary>
		
		ENDIAN_BIG = 0,
		/// <summary>
		/// The numbers are stored in little endian format, such as those used by Intel and AMD x86 processors.
		/// </summary>
		
		ENDIAN_LITTLE = 1,
	}
	

}
