using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle modifier that adds a defined shape to act as a collision object for particles to interact with.
	///         
	/// </summary>
	public class NiPSysColliderManager : NiPSysModifier
	{
		/// <summary>
		/// Link to a NiPSysPlanarCollider or NiPSysSphericalCollider.
		/// </summary>
		public Ptr<NiPSysCollider> Collider { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Collider = reader.Read<Ptr<NiPSysCollider>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Collider);
			
		}
	}
	

}
