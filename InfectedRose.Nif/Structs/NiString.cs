using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A string type.
	///         
	/// </summary>
	public class NiString : IConstruct
	{
		/// <summary>
		/// The string index.
		/// </summary>
		public uint Index { get; set; }

		public string Get(NiFile file)
		{
			return Index == uint.MaxValue ? "" : file.Header.Strings[Index];
		}
		
		public void Deserialize(BitReader reader)
		{
			Index = reader.Read<uint>();
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Index);
			
		}
	}
	

}
