using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class CStreamableAssetData : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiNode> Root { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte[] UnknownBytes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Root = reader.Read<Ptr<NiNode>>();
			
			UnknownBytes = new byte[5];
			for (var i = 0; i < 5; i++)
			{
				UnknownBytes[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Root);
			
			for (var i = 0; i < 5; i++)
			{
				writer.Write(UnknownBytes[i]);
			}
			
		}
	}
	

}
