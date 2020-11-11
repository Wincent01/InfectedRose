using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiFloatsExtraData : NiExtraData
	{
		/// <summary>
		/// Number of floats in the next field.
		/// </summary>
		public uint NumFloats { get; set; } 
		
		/// <summary>
		/// Float data.
		/// </summary>
		public float[] Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumFloats = reader.Read<uint>();
			
			Data = new float[NumFloats];
			for (var i = 0; i < NumFloats; i++)
			{
				Data[i] = reader.Read<float>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumFloats);
			
			for (var i = 0; i < NumFloats; i++)
			{
				writer.Write(Data[i]);
			}
			
		}
	}
	

}
