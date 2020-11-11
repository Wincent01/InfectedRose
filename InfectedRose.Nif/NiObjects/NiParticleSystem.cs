using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle system.
	/// 		
	/// </summary>
	public class NiParticleSystem : NiParticles
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public ushort UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public ushort UnknownShort3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// If true, Particles are birthed into world space.  If false, Particles are birthed into object space.
		/// </summary>
		public bool WorldSpace { get; set; } 
		
		/// <summary>
		/// The number of modifier references.
		/// </summary>
		public uint NumModifiers { get; set; } 
		
		/// <summary>
		/// The list of particle modifiers.
		/// </summary>
		public Ptr<NiPSysModifier>[] Modifiers { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort2 = reader.Read<ushort>();
			
			UnknownShort3 = reader.Read<ushort>();
			
			UnknownInt1 = reader.Read<uint>();
			
			WorldSpace = reader.Read<byte>() != 0;
			
			NumModifiers = reader.Read<uint>();
			
			Modifiers = new Ptr<NiPSysModifier>[NumModifiers];
			for (var i = 0; i < NumModifiers; i++)
			{
				Modifiers[i] = reader.Read<Ptr<NiPSysModifier>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort2);
			
			writer.Write(UnknownShort3);
			
			writer.Write(UnknownInt1);
			
			writer.Write((byte) (WorldSpace ? 1 : 0));
			
			writer.Write(NumModifiers);
			
			for (var i = 0; i < NumModifiers; i++)
			{
				writer.Write(Modifiers[i]);
			}
			
		}
	}
	

}
