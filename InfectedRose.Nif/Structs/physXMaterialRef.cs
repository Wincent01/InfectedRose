using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct physXMaterialRef : IConstruct
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public byte Number { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// PhysX Material Description
		/// </summary>
		public Ptr<NiPhysXMaterialDesc> MaterialDesc { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Number = reader.Read<byte>();
			
			UnknownByte1 = reader.Read<byte>();
			
			MaterialDesc = reader.Read<Ptr<NiPhysXMaterialDesc>>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Number);
			
			writer.Write(UnknownByte1);
			
			writer.Write(MaterialDesc);
			
		}
	}
	

}
