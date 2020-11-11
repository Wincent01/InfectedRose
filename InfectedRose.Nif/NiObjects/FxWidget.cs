using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Firaxis-specific UI widgets?
	///         
	/// </summary>
	public class FxWidget : NiNode
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte Unknown3 { get; set; } 
		
		/// <summary>
		/// Looks like 9 links and some string data.
		/// </summary>
		public byte[] Unknown292Bytes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown3 = reader.Read<byte>();
			
			Unknown292Bytes = new byte[292];
			for (var i = 0; i < 292; i++)
			{
				Unknown292Bytes[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown3);
			
			for (var i = 0; i < 292; i++)
			{
				writer.Write(Unknown292Bytes[i]);
			}
			
		}
	}
	

}
