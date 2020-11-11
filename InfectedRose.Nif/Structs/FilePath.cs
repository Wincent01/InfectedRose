using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A string that contains the path to a file.
	///         
	/// </summary>
	public struct FilePath : IConstruct
	{
		/// <summary>
		/// The string index.
		/// </summary>
		public uint Index { get; set; } 
		
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
