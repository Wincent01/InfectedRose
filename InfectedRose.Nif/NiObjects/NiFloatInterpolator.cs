using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiFloatInterpolator : NiKeyBasedInterpolator
	{
		/// <summary>
		/// Value when posed?  At time 0?
		/// </summary>
		public float FloatValue { get; set; } 
		
		/// <summary>
		/// Float data?
		/// </summary>
		public Ptr<NiFloatData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			FloatValue = reader.Read<float>();
			
			Data = reader.Read<Ptr<NiFloatData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(FloatValue);
			
			writer.Write(Data);
			
		}
	}
	

}
