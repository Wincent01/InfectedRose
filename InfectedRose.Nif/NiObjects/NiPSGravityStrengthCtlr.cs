using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSGravityStrengthCtlr : NiTimeController
	{
		/// <summary>
		/// 
		/// </summary>
		public int Unknown2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown2 = reader.Read<int>();
			
			Unknown3 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown2);
			
			writer.Write(Unknown3);
			
		}
	}
	

}
