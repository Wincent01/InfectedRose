using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Abstract base class for a single step in the particle system simulation process.  It has no seralized data.
	///     
	/// </summary>
	public abstract class NiPSSimulatorStep : NiObject
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
