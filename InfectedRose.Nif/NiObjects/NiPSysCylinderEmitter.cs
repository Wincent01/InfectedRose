using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle emitter that uses points within a defined Cylinder shape to emit from.
	///         
	/// </summary>
	public class NiPSysCylinderEmitter : NiPSysVolumeEmitter
	{
		/// <summary>
		/// Radius of the cylinder shape.
		/// </summary>
		public float Radius { get; set; } 
		
		/// <summary>
		/// Height of the cylinders shape.
		/// </summary>
		public float Height { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Radius = reader.Read<float>();
			
			Height = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Radius);
			
			writer.Write(Height);
			
		}
	}
	

}
