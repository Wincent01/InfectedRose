using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiFloatExtraDataController : NiExtraDataController
	{
		/// <summary>
		/// Refers to a NiFloatExtraData name.
		/// </summary>
		public NiString ControllerData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ControllerData = new NiString();
			ControllerData.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ControllerData);
			
		}
	}
	

}
