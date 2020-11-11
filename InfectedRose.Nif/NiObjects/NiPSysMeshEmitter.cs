using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle emitter that uses points on a specified mesh to emit from.
	///         
	/// </summary>
	public class NiPSysMeshEmitter : NiPSysEmitter
	{
		/// <summary>
		/// The number of references to emitter meshes that follow.
		/// </summary>
		public uint NumEmitterMeshes { get; set; } 
		
		/// <summary>
		/// Links to meshes used for emitting.
		/// </summary>
		public Ptr<NiTriBasedGeom>[] EmitterMeshes { get; set; } 
		
		/// <summary>
		/// The way the particles get their initial direction and speed.
		/// </summary>
		public VelocityType InitialVelocityType { get; set; } 
		
		/// <summary>
		/// The parts of the mesh that the particles emit from.
		/// </summary>
		public EmitFrom EmissionType { get; set; } 
		
		/// <summary>
		/// The emission axis.
		/// </summary>
		public Vector3 EmissionAxis { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumEmitterMeshes = reader.Read<uint>();
			
			EmitterMeshes = new Ptr<NiTriBasedGeom>[NumEmitterMeshes];
			for (var i = 0; i < NumEmitterMeshes; i++)
			{
				EmitterMeshes[i] = reader.Read<Ptr<NiTriBasedGeom>>();
			}
			
			InitialVelocityType = (VelocityType) reader.Read<uint>();
			
			EmissionType = (EmitFrom) reader.Read<uint>();
			
			EmissionAxis = new Vector3();
			EmissionAxis.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumEmitterMeshes);
			
			for (var i = 0; i < NumEmitterMeshes; i++)
			{
				writer.Write(EmitterMeshes[i]);
			}
			
			writer.Write((uint) InitialVelocityType);
			
			writer.Write((uint) EmissionType);
			
			writer.Write(EmissionAxis);
			
		}
	}
	

}
