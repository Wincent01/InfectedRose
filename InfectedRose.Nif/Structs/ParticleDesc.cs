using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle Description.
	///         
	/// </summary>
	public class ParticleDesc : IConstruct
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public Vector3 Translation { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat3 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownInt1 = reader.Read<int>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Translation);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownInt1);
			
		}
	}
	

}
