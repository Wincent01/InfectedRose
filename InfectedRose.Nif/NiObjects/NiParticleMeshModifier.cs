using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiParticleMeshModifier : NiParticleModifier
	{
		/// <summary>
		/// The number of particle mesh references that follow.
		/// </summary>
		public uint NumParticleMeshes { get; set; } 
		
		/// <summary>
		/// Links to nodes of particle meshes?
		/// </summary>
		public Ptr<NiAVObject>[] ParticleMeshes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumParticleMeshes = reader.Read<uint>();
			
			ParticleMeshes = new Ptr<NiAVObject>[NumParticleMeshes];
			for (var i = 0; i < NumParticleMeshes; i++)
			{
				ParticleMeshes[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumParticleMeshes);
			
			for (var i = 0; i < NumParticleMeshes; i++)
			{
				writer.Write(ParticleMeshes[i]);
			}
			
		}
	}
	

}
