using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes a mesh, built from triangles.
	///     
	/// </summary>
	public abstract class NiTriBasedGeom : NiGeometry
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
