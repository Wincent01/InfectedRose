using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown
	///         
	/// </summary>
	public class NiTextureModeProperty : NiProperty
	{
		/// <summary>
		/// Unknown. Either 210 or 194.
		/// </summary>
		public short UnknownShort { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<short>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
		}
	}
	

}
