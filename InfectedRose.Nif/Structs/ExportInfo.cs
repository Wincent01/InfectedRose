using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///     	Information about how the file was exported
	///         
	/// </summary>
	public class ExportInfo : IConstruct
	{
		/// <summary>
		/// Could be the name of the creator of the NIF file?
		/// </summary>
		public ShortString Creator { get; set; } 
		
		/// <summary>
		/// Unknown. Can be something like 'TriStrip Process Script'.
		/// </summary>
		public ShortString ExportInfo1 { get; set; } 
		
		/// <summary>
		/// Unknown. Possibly the selected option of the export script. Can be something like 'Default Export Script'.
		/// </summary>
		public ShortString ExportInfo2 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Creator = new ShortString();
			Creator.Deserialize(reader);
			
			ExportInfo1 = new ShortString();
			ExportInfo1.Deserialize(reader);
			
			ExportInfo2 = new ShortString();
			ExportInfo2.Deserialize(reader);
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Creator);
			
			writer.Write(ExportInfo1);
			
			writer.Write(ExportInfo2);
			
		}
	}
	

}
