using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A range of indices, which make up a region (such as a submesh).
	///         
	/// </summary>
	public struct Region : IConstruct
	{
		/// <summary>
		/// 
		/// </summary>
		public uint StartIndex { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public uint NumIndices { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			StartIndex = reader.Read<uint>();
			
			NumIndices = reader.Read<uint>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(StartIndex);
			
			writer.Write(NumIndices);
			
		}
	}
	

}
