using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Integers data.
	///         
	/// </summary>
	public class NiIntegersExtraData : NiExtraData
	{
		/// <summary>
		/// Number of integers.
		/// </summary>
		public uint NumIntegers { get; set; } 
		
		/// <summary>
		/// Integers.
		/// </summary>
		public uint[] Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumIntegers = reader.Read<uint>();
			
			Data = new uint[NumIntegers];
			for (var i = 0; i < NumIntegers; i++)
			{
				Data[i] = reader.Read<uint>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumIntegers);
			
			for (var i = 0; i < NumIntegers; i++)
			{
				writer.Write(Data[i]);
			}
			
		}
	}
	

}
