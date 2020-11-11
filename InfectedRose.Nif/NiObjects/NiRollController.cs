using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiRollController : NiSingleInterpController
	{
		/// <summary>
		/// The data for the controller.
		/// </summary>
		public Ptr<NiFloatData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = reader.Read<Ptr<NiFloatData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
