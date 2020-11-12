using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Stores Bone Level of Detail info in a BSBoneLODExtraData
	///         
	/// </summary>
	public class BoneLOD : IConstruct
	{
		/// <summary>
		/// Distance to cull?
		/// </summary>
		public uint Distance { get; set; } 
		
		/// <summary>
		/// The bones name
		/// </summary>
		public NiString BoneName { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Distance = reader.Read<uint>();
			
			BoneName = new NiString();
			BoneName.Deserialize(reader);
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Distance);
			
			writer.Write(BoneName);
			
		}
	}
	

}
