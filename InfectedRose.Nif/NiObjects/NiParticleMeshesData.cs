using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle meshes data.
	///         
	/// </summary>
	public class NiParticleMeshesData : NiRotatingParticlesData
	{
		/// <summary>
		/// Refers to the mesh that makes up a particle?
		/// </summary>
		public Ptr<NiAVObject> UnknownLink2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownLink2 = reader.Read<Ptr<NiAVObject>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownLink2);
			
		}
	}
	

}
