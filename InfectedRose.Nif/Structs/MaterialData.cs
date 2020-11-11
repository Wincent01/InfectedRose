using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Data stored per-material by NiRenderObject
	///         
	/// </summary>
	public struct MaterialData : IConstruct
	{
		/// <summary>
		/// The name of the material.
		/// </summary>
		public NiString MaterialName { get; set; } 
		
		/// <summary>
		/// Extra data associated with the material?
		/// </summary>
		public uint MaterialExtraData { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			MaterialName = new NiString();
			MaterialName.Deserialize(reader);
			
			MaterialExtraData = reader.Read<uint>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(MaterialName);
			
			writer.Write(MaterialExtraData);
			
		}
	}
	

}
