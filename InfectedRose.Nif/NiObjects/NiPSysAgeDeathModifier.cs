using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown particle modifier.
	///         
	/// </summary>
	public class NiPSysAgeDeathModifier : NiPSysModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public bool SpawnonDeath { get; set; } 
		
		/// <summary>
		/// Link to NiPSysSpawnModifier object?
		/// </summary>
		public Ptr<NiPSysSpawnModifier> SpawnModifier { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			SpawnonDeath = reader.Read<byte>() != 0;
			
			SpawnModifier = reader.Read<Ptr<NiPSysSpawnModifier>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((byte) (SpawnonDeath ? 1 : 0));
			
			writer.Write(SpawnModifier);
			
		}
	}
	

}
