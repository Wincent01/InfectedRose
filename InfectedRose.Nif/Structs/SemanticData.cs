using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class SemanticData : IConstruct
	{
		/// <summary>
		/// 
		///             Type of data (POSITION, POSITION_BP, INDEX, NORMAL, NORMAL_BP,
		///             TEXCOORD, BLENDINDICES, BLENDWEIGHT, BONE_PALETTE, COLOR, DISPLAYLIST,
		///             MORPH_POSITION, BINORMAL_BP, TANGENT_BP).
		///         
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// 
		///             An extra index of the data. For example, if there are 3 uv maps,
		///             then the corresponding TEXCOORD data components would have indices
		///             0, 1, and 2, respectively.
		///         
		/// </summary>
		public uint Index { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Name = new NiString();
			Name.Deserialize(reader);
			
			Index = reader.Read<uint>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Name);
			
			writer.Write(Index);
			
		}
	}
	

}
