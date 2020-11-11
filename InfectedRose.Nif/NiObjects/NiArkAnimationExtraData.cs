using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.
	///         
	/// </summary>
	public class NiArkAnimationExtraData : NiExtraData
	{
		/// <summary>
		/// 
		/// </summary>
		public int[] UnknownInts { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInts = new int[4];
			for (var i = 0; i < 4; i++)
			{
				UnknownInts[i] = reader.Read<int>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 4; i++)
			{
				writer.Write(UnknownInts[i]);
			}
			
		}
	}
	

}
