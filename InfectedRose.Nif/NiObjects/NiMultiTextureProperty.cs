using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         (note: not quite complete yet... but already reads most of the DAoC ones)
	///         
	/// </summary>
	public class NiMultiTextureProperty : NiProperty
	{
		/// <summary>
		/// Property flags.
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Unknown. Always 5 for DAoC files, and always 6 for Bridge Commander.  Seems to have nothing to do with the number of Texture Element slots that follow.
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Describes the various textures used by this mutli-texture property.  Each slot probably has special meaning like thoes in NiTexturingProperty.
		/// </summary>
		public MultiTextureElement[] TextureElements { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			UnknownInt = reader.Read<uint>();
			
			TextureElements = new MultiTextureElement[5];
			for (var i = 0; i < 5; i++)
			{
				var value = new MultiTextureElement();
				value.Deserialize(reader);
				TextureElements[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(UnknownInt);
			
			for (var i = 0; i < 5; i++)
			{
				writer.Write(TextureElements[i]);
			}
			
		}
	}
	

}
