using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle system modifier.
	///         
	/// </summary>
	public abstract class NiParticleModifier : NiObject
	{
		/// <summary>
		/// Next particle modifier.
		/// </summary>
		public Ptr<NiParticleModifier> NextModifier { get; set; } 
		
		/// <summary>
		/// Points to the particle system controller parent.
		/// </summary>
		public Ptr<NiParticleSystemController> Controller { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NextModifier = reader.Read<Ptr<NiParticleModifier>>();
			
			Controller = reader.Read<Ptr<NiParticleSystemController>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NextModifier);
			
			writer.Write(Controller);
			
		}
	}
	

}
