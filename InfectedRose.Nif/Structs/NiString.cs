using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A string type.
	///         
	/// </summary>
	public struct NiString : IConstruct
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
