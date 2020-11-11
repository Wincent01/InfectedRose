using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Texture flipping controller.
	///         
	/// </summary>
	public class NiFlipController : NiFloatInterpController
	{
		/// <summary>
		/// Target texture slot (0=base, 4=glow).
		/// </summary>
		public TexType TextureSlot { get; set; } 
		
		/// <summary>
		/// The number of source objects.
		/// </summary>
		public uint NumSources { get; set; } 
		
		/// <summary>
		/// The texture sources.
		/// </summary>
		public Ptr<NiSourceTexture>[] Sources { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			TextureSlot = (TexType) reader.Read<uint>();
			
			NumSources = reader.Read<uint>();
			
			Sources = new Ptr<NiSourceTexture>[NumSources];
			for (var i = 0; i < NumSources; i++)
			{
				Sources[i] = reader.Read<Ptr<NiSourceTexture>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((uint) TextureSlot);
			
			writer.Write(NumSources);
			
			for (var i = 0; i < NumSources; i++)
			{
				writer.Write(Sources[i]);
			}
			
		}
	}
	

}
