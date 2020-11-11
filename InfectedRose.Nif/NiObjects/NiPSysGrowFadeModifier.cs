using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle modifier that controls the time it takes to grow a particle from Size=0 to the specified Size in the emitter, and then back to 0.  This modifer has no control over alpha settings.
	///         
	/// </summary>
	public class NiPSysGrowFadeModifier : NiPSysModifier
	{
		/// <summary>
		/// Time in seconds to fade in.
		/// </summary>
		public float GrowTime { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort GrowGeneration { get; set; } 
		
		/// <summary>
		/// Time in seconds to fade out.
		/// </summary>
		public float FadeTime { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort FadeGeneration { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public float BaseScale { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			GrowTime = reader.Read<float>();
			
			GrowGeneration = reader.Read<ushort>();
			
			FadeTime = reader.Read<float>();
			
			FadeGeneration = reader.Read<ushort>();
			
			BaseScale = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(GrowTime);
			
			writer.Write(GrowGeneration);
			
			writer.Write(FadeTime);
			
			writer.Write(FadeGeneration);
			
			writer.Write(BaseScale);
			
		}
	}
	

}
