using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Apparently commands for an optimizer instructing it to keep things it would normally discard.
	///         Also refers to NiNode objects (through their name) in animation .kf files.
	///         
	/// </summary>
	public class NiStringExtraData : NiExtraData
	{
		/// <summary>
		/// The string.
		/// </summary>
		public NiString StringData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			StringData = new NiString();
			StringData.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(StringData);
			
		}
	}
	

}
