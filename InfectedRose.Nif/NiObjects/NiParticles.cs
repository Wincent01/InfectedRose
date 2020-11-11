using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Generic particle system node.
	///     
	/// </summary>
	public class NiParticles : NiGeometry
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
