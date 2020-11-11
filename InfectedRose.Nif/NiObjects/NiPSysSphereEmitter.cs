using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle emitter that uses points within a sphere shape to emit from.
	///         
	/// </summary>
	public class NiPSysSphereEmitter : NiPSysVolumeEmitter
	{
		/// <summary>
		/// The radius of the sphere shape
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
