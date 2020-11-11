using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system emitter controller.
	///         
	/// </summary>
	public class NiPSysEmitterCtlr : NiPSysModifierCtlr
	{
		/// <summary>
		/// Links to a bool interpolator. Controls emitter's visibility status?
		/// </summary>
		public Ptr<NiInterpolator> VisibilityInterpolator { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			VisibilityInterpolator = reader.Read<Ptr<NiInterpolator>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(VisibilityInterpolator);
			
		}
	}
	

}
