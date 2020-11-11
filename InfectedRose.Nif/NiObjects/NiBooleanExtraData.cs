using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Boolean extra data.
	///         
	/// </summary>
	public class NiBooleanExtraData : NiExtraData
	{
		/// <summary>
		/// The boolean extra data value.
		/// </summary>
		public byte BooleanData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BooleanData = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(BooleanData);
			
		}
	}
	

}
