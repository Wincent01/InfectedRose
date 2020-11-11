using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiParticleColorModifier : NiParticleModifier
	{
		/// <summary>
		/// Color data index.
		/// </summary>
		public Ptr<NiColorData> ColorData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ColorData = reader.Read<Ptr<NiColorData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ColorData);
			
		}
	}
	

}
