using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiTextureProperty : NiProperty
	{
		/// <summary>
		/// Property flags.
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Link to the texture image.
		/// </summary>
		public Ptr<NiImage> Image { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			Image = reader.Read<Ptr<NiImage>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(Image);
			
		}
	}
	

}
