using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Timed boolean data.
	///         
	/// </summary>
	public class NiBoolData : NiObject
	{
		/// <summary>
		/// The boolean keys.
		/// </summary>
		public KeyGroup<NiConstruct<byte>> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = new KeyGroup<NiConstruct<byte>>();
			Data.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
