using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSMeshParticleSystem : NiPSParticleSystem
	{
		/// <summary>
		/// 
		/// </summary>
		public int Unknown23 { get; set; } 
		
		/// <summary>
		/// Unknown - may or may not be emitted mesh?
		/// </summary>
		public int Unknown24 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown25 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown26 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown23 = reader.Read<int>();
			
			Unknown24 = reader.Read<int>();
			
			Unknown25 = reader.Read<int>();
			
			Unknown26 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown23);
			
			writer.Write(Unknown24);
			
			writer.Write(Unknown25);
			
			writer.Write(Unknown26);
			
		}
	}
	

}
