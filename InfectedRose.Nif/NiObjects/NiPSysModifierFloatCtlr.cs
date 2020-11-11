using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle system modifier controller that deals with floating point data?
	///         
	/// </summary>
	public abstract class NiPSysModifierFloatCtlr : NiPSysModifierCtlr
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
