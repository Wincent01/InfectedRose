using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An extended texture description for shader textures.
	///         
	/// </summary>
	public struct ShaderTexDesc : IConstruct
	{
		/// <summary>
		/// Is it used?
		/// </summary>
		public bool IsUsed { get; set; } 
		
		/// <summary>
		/// The texture data.
		/// </summary>
		public TexDesc TextureData { get; set; } 
		
		/// <summary>
		/// Map Index
		/// </summary>
		public uint MapIndex { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			IsUsed = reader.Read<byte>() != 0;
			
			if (IsUsed)
			{
				TextureData = new TexDesc();
				TextureData.Deserialize(reader);
				
			}
			if (IsUsed)
			{
				MapIndex = reader.Read<uint>();
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write((byte) (IsUsed ? 1 : 0));
			
			if (IsUsed)
			{
				writer.Write(TextureData);
				
			}
			if (IsUsed)
			{
				writer.Write(MapIndex);
				
			}
		}
	}
	

}
