using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         List of 0x00-seperated strings, which are names of controlled objects and controller types. Used in .kf files in conjunction with NiControllerSequence.
	///         
	/// </summary>
	public class NiStringPalette : NiObject
	{
		/// <summary>
		/// A bunch of 0x00 seperated strings.
		/// </summary>
		public StringPalette Palette { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Palette = new StringPalette();
			Palette.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Palette);
			
		}
	}
	

}
