using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A shape node that refers to data organized into strips of triangles
	///     
	/// </summary>
	public class NiTriStrips : NiTriBasedGeom
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
