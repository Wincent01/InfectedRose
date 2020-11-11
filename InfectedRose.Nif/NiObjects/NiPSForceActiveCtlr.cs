using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSForceActiveCtlr : NiTimeController
	{
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiObject> Interpolator { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Interpolator = reader.Read<Ptr<NiObject>>();
			
			Unknown2 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Interpolator);
			
			writer.Write(Unknown2);
			
		}
	}
	

}
