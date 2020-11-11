using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown! Used by Daoc.
	///         
	/// </summary>
	public class NiMorpherController : NiInterpController
	{
		/// <summary>
		/// This controller's data.
		/// </summary>
		public Ptr<NiMorphData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = reader.Read<Ptr<NiMorphData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
