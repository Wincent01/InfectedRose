using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Body part list for DismemberSkinInstance
	///         
	/// </summary>
	public class BodyPartList : IConstruct
	{
		public ushort PartFlag { get; set; }
		
		public ushort BodyPart { get; set; }
		
		public void Deserialize(BitReader reader)
		{
			PartFlag = reader.Read<ushort>();

			BodyPart = reader.Read<ushort>();
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(PartFlag);
			
			writer.Write((ushort) BodyPart);
			
		}
	}
	

}
