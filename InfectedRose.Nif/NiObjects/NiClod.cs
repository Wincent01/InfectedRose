using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A shape node that holds continuous level of detail information.
	///         Seems to be specific to Freedom Force.
	///     
	/// </summary>
	public class NiClod : NiTriBasedGeom
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
