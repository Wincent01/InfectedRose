using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class ElementReference : IConstruct
	{
		/// <summary>
		/// The element semantic.
		/// </summary>
		public SemanticData Semantic { get; set; } 
		
		/// <summary>
		/// Whether or not to normalize the data.
		/// </summary>
		public uint NormalizeFlag { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Semantic = new SemanticData();
			Semantic.Deserialize(reader);
			
			NormalizeFlag = reader.Read<uint>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Semantic);
			
			writer.Write(NormalizeFlag);
			
		}
	}
	

}
