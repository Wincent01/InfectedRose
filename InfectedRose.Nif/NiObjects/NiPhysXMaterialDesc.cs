using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.
	///         
	/// </summary>
	public class NiPhysXMaterialDesc : NiObject
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public uint[] UnknownInt { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt = new uint[12];
			for (var i = 0; i < 12; i++)
			{
				UnknownInt[i] = reader.Read<uint>();
			}
			
			UnknownByte1 = reader.Read<byte>();
			
			UnknownByte2 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 12; i++)
			{
				writer.Write(UnknownInt[i]);
			}
			
			writer.Write(UnknownByte1);
			
			writer.Write(UnknownByte2);
			
		}
	}
	

}
