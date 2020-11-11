using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSBoundUpdater : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = reader.Read<byte>();
			
			Unknown2 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown1);
			
			writer.Write(Unknown2);
			
		}
	}
	

}
