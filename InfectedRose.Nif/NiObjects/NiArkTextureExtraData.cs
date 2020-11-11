using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.
	///         
	/// </summary>
	public class NiArkTextureExtraData : NiExtraData
	{
		/// <summary>
		/// 
		/// </summary>
		public int[] UnknownInts1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte UnknownByte { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int NumTextures { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ArkTexture[] Textures { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInts1 = new int[2];
			for (var i = 0; i < 2; i++)
			{
				UnknownInts1[i] = reader.Read<int>();
			}
			
			UnknownByte = reader.Read<byte>();
			
			NumTextures = reader.Read<int>();
			
			Textures = new ArkTexture[NumTextures];
			for (var i = 0; i < NumTextures; i++)
			{
				var value = new ArkTexture();
				value.Deserialize(reader);
				Textures[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 2; i++)
			{
				writer.Write(UnknownInts1[i]);
			}
			
			writer.Write(UnknownByte);
			
			writer.Write(NumTextures);
			
			for (var i = 0; i < NumTextures; i++)
			{
				writer.Write(Textures[i]);
			}
			
		}
	}
	

}
