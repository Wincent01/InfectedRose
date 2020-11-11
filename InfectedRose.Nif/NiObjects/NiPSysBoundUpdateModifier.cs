using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown particle system modifier.
	///         
	/// </summary>
	public class NiPSysBoundUpdateModifier : NiPSysModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UpdateSkip { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UpdateSkip = reader.Read<ushort>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UpdateSkip);
			
		}
	}
	

}
