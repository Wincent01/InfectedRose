using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A list of \\0 terminated strings.
	///         
	/// </summary>
	public struct StringPalette : IConstruct
	{
		/// <summary>
		/// A bunch of 0x00 seperated strings.
		/// </summary>
		public SizedString Palette { get; set; } 
		
		/// <summary>
		/// Length of the palette string is repeated here.
		/// </summary>
		public uint Length { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Palette = new SizedString();
			Palette.Deserialize(reader);
			
			Length = reader.Read<uint>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Palette);
			
			writer.Write(Length);
			
		}
	}
	

}
