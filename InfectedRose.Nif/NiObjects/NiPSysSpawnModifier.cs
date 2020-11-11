using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown particle modifier.
	///         
	/// </summary>
	public class NiPSysSpawnModifier : NiPSysModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort NumSpawnGenerations { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float PercentageSpawned { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort MinNumtoSpawn { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort MaxNumtoSpawn { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float SpawnSpeedChaos { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float SpawnDirChaos { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float LifeSpan { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float LifeSpanVariation { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumSpawnGenerations = reader.Read<ushort>();
			
			PercentageSpawned = reader.Read<float>();
			
			MinNumtoSpawn = reader.Read<ushort>();
			
			MaxNumtoSpawn = reader.Read<ushort>();
			
			SpawnSpeedChaos = reader.Read<float>();
			
			SpawnDirChaos = reader.Read<float>();
			
			LifeSpan = reader.Read<float>();
			
			LifeSpanVariation = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumSpawnGenerations);
			
			writer.Write(PercentageSpawned);
			
			writer.Write(MinNumtoSpawn);
			
			writer.Write(MaxNumtoSpawn);
			
			writer.Write(SpawnSpeedChaos);
			
			writer.Write(SpawnDirChaos);
			
			writer.Write(LifeSpan);
			
			writer.Write(LifeSpanVariation);
			
		}
	}
	

}
