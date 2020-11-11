using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A texture reference used by NiArkTextureExtraData.
	///         
	/// </summary>
	public struct ArkTexture : IConstruct
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString TextureName { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiTexturingProperty> TexturingProperty { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte[] UnknownBytes { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			TextureName = new NiString();
			TextureName.Deserialize(reader);
			
			UnknownInt3 = reader.Read<int>();
			
			UnknownInt4 = reader.Read<int>();
			
			TexturingProperty = reader.Read<Ptr<NiTexturingProperty>>();
			
			UnknownBytes = new byte[9];
			for (var i = 0; i < 9; i++)
			{
				UnknownBytes[i] = reader.Read<byte>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(TextureName);
			
			writer.Write(UnknownInt3);
			
			writer.Write(UnknownInt4);
			
			writer.Write(TexturingProperty);
			
			for (var i = 0; i < 9; i++)
			{
				writer.Write(UnknownBytes[i]);
			}
			
		}
	}
	

}
