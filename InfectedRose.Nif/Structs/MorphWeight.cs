using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct MorphWeight : IConstruct
	{
		/// <summary>
		/// Interpolator
		/// </summary>
		public Ptr<NiInterpolator> Interpolator { get; set; } 
		
		/// <summary>
		/// Weight
		/// </summary>
		public float Weight { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Interpolator = reader.Read<Ptr<NiInterpolator>>();
			
			Weight = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Interpolator);
			
			writer.Write(Weight);
			
		}
	}
	

}
