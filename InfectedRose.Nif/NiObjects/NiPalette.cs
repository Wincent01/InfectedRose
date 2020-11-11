using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A color palette.
	///         
	/// </summary>
	public class NiPalette : NiObject
	{
		/// <summary>
		/// Unknown, Usually = 0.
		/// </summary>
		public byte UnknownByte { get; set; } 
		
		/// <summary>
		/// The number of palette entries.  Always = 256.
		/// </summary>
		public uint NumEntries { get; set; } 
		
		/// <summary>
		/// The color palette.
		/// </summary>
		public ByteColor4[] Palette { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownByte = reader.Read<byte>();
			
			NumEntries = reader.Read<uint>();
			
			Palette = new ByteColor4[256];
			for (var i = 0; i < 256; i++)
			{
				var value = new ByteColor4();
				value.Deserialize(reader);
				Palette[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownByte);
			
			writer.Write(NumEntries);
			
			for (var i = 0; i < 256; i++)
			{
				writer.Write(Palette[i]);
			}
			
		}
	}
	

}
