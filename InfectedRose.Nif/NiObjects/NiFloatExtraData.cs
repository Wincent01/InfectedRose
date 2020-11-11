using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Float extra data.
	///         
	/// </summary>
	public class NiFloatExtraData : NiExtraData
	{
		/// <summary>
		/// The float data.
		/// </summary>
		public float FloatData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			FloatData = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(FloatData);
			
		}
	}
	

}
