using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The distance range where a specific level of detail applies.
	///         
	/// </summary>
	public class LODRange : IConstruct
	{
		/// <summary>
		/// Begining of range.
		/// </summary>
		public float NearExtent { get; set; } 
		
		/// <summary>
		/// End of Range.
		/// </summary>
		public float FarExtent { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NearExtent = reader.Read<float>();
			
			FarExtent = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NearExtent);
			
			writer.Write(FarExtent);
			
		}
	}
	

}
