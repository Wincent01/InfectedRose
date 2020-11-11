using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown!
	///         
	/// </summary>
	public class Ni3dsPathController : NiObject
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte[] Unknown1 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = new byte[20];
			for (var i = 0; i < 20; i++)
			{
				Unknown1[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 20; i++)
			{
				writer.Write(Unknown1[i]);
			}
			
		}
	}
	

}
