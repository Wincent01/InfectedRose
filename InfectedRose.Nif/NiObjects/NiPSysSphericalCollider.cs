using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle Collider object which particles will interact with.
	///         
	/// </summary>
	public class NiPSysSphericalCollider : NiPSysCollider
	{
		/// <summary>
		/// Defines the radius of the sphere object.
		/// </summary>
		public float Radius { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Radius = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Radius);
			
		}
	}
	

}
