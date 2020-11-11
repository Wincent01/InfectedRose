using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.
	///         
	/// </summary>
	public class NiArkViewportInfoExtraData : NiExtraData
	{
		/// <summary>
		/// 
		/// </summary>
		public byte[] UnknownBytes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownBytes = new byte[13];
			for (var i = 0; i < 13; i++)
			{
				UnknownBytes[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 13; i++)
			{
				writer.Write(UnknownBytes[i]);
			}
			
		}
	}
	

}
