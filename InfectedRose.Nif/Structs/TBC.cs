using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Tension, bias, continuity.
	///         
	/// </summary>
	public class TBC : IConstruct
	{
		/// <summary>
		/// Tension.
		/// </summary>
		public float t { get; set; } 
		
		/// <summary>
		/// Bias.
		/// </summary>
		public float b { get; set; } 
		
		/// <summary>
		/// Continuity.
		/// </summary>
		public float c { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			t = reader.Read<float>();
			
			b = reader.Read<float>();
			
			c = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(t);
			
			writer.Write(b);
			
			writer.Write(c);
			
		}
	}
	

}
