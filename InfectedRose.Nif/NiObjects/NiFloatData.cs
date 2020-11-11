using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Possibly the 1D position along a 3D path.
	///         
	/// </summary>
	public class NiFloatData : NiObject
	{
		/// <summary>
		/// The keys.
		/// </summary>
		public KeyGroup<float> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = new KeyGroup<float>();
			Data.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
