using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown
	///         
	/// </summary>
	public class NiTransparentProperty : NiProperty
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte[] Unknown { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown = new byte[6];
			for (var i = 0; i < 6; i++)
			{
				Unknown[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 6; i++)
			{
				writer.Write(Unknown[i]);
			}
			
		}
	}
	

}
