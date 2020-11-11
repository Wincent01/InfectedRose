using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system controller for emitter initial rotation angle.
	///     
	/// </summary>
	public class NiPSysInitialRotAngleCtlr : NiPSysModifierFloatCtlr
	{
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
		}
	}
	

}
