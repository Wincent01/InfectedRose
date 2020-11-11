using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Generic particle system modifier object.
	///         
	/// </summary>
	public abstract class NiPSysModifier : NiObject
	{
		/// <summary>
		/// The object name.
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// Modifier ID in the particle modifier chain (always a multiple of 1000)?
		/// </summary>
		public uint Order { get; set; } 
		
		/// <summary>
		/// NiParticleSystem parent of this modifier.
		/// </summary>
		public Ptr<NiParticleSystem> Target { get; set; } 
		
		/// <summary>
		/// Whether the modifier is currently in effect?  Usually true.
		/// </summary>
		public bool Active { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			Order = reader.Read<uint>();
			
			Target = reader.Read<Ptr<NiParticleSystem>>();
			
			Active = reader.Read<byte>() != 0;
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
			writer.Write(Order);
			
			writer.Write(Target);
			
			writer.Write((byte) (Active ? 1 : 0));
			
		}
	}
	

}
