using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle modifier that adds keyframe data to modify color/alpha values of particles over time.
	///         
	/// </summary>
	public class NiPSysColorModifier : NiPSysModifier
	{
		/// <summary>
		/// Refers to NiColorData object.
		/// </summary>
		public Ptr<NiColorData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = reader.Read<Ptr<NiColorData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
