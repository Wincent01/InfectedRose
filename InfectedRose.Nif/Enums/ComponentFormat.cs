using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The data format of components.
	///         
	/// </summary>
	public enum ComponentFormat : uint
	{
		/// <summary>
		/// Unknown, or don't care, format.
		/// </summary>
		
		F_UNKNOWN = 0x00000000,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT8_1 = 0x00010101,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT8_2 = 0x00020102,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT8_3 = 0x00030103,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT8_4 = 0x00040104,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT8_1 = 0x00010105,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT8_2 = 0x00020106,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT8_3 = 0x00030107,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT8_4 = 0x00040108,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT8_1 = 0x00010109,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT8_2 = 0x0002010A,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT8_3 = 0x0003010B,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT8_4 = 0x0004010C,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT8_1 = 0x0001010D,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT8_2 = 0x0002010E,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT8_3 = 0x0003010F,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT8_4 = 0x00040110,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT16_1 = 0x00010211,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT16_2 = 0x00020212,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT16_3 = 0x00030213,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT16_4 = 0x00040214,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT16_1 = 0x00010215,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT16_2 = 0x00020216,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT16_3 = 0x00030217,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT16_4 = 0x00040218,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT16_1 = 0x00010219,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT16_2 = 0x0002021A,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT16_3 = 0x0003021B,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT16_4 = 0x0004021C,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT16_1 = 0x0001021D,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT16_2 = 0x0002021E,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT16_3 = 0x0003021F,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT16_4 = 0x00040220,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT32_1 = 0x00010421,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT32_2 = 0x00020422,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT32_3 = 0x00030423,
		/// <summary>
		/// 
		/// </summary>
		
		F_INT32_4 = 0x00040424,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT32_1 = 0x00010425,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT32_2 = 0x00020426,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT32_3 = 0x00030427,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT32_4 = 0x00040428,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT32_1 = 0x00010429,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT32_2 = 0x0002042A,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT32_3 = 0x0003042B,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT32_4 = 0x0004042C,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT32_1 = 0x0001042D,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT32_2 = 0x0002042E,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT32_3 = 0x0003042F,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT32_4 = 0x00040430,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT16_1 = 0x00010231,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT16_2 = 0x00020232,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT16_3 = 0x00030233,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT16_4 = 0x00040234,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT32_1 = 0x00010435,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT32_2 = 0x00020436,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT32_3 = 0x00030437,
		/// <summary>
		/// 
		/// </summary>
		
		F_FLOAT32_4 = 0x00040438,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT_10_10_10_L1 = 0x00010439,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT_10_10_10_L1 = 0x0001043A,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT_11_11_10 = 0x0001043B,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMUINT8_4_BGRA = 0x0004013C,
		/// <summary>
		/// 
		/// </summary>
		
		F_NORMINT_10_10_10_2 = 0x0001043D,
		/// <summary>
		/// 
		/// </summary>
		
		F_UINT_10_10_10_2 = 0x0001043E,
	}
	

}
