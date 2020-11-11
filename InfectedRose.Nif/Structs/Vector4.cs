using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A 4-dimensional vector.
	///         
	/// </summary>
	public struct Vector4 : IConstruct
	{
		/// <summary>
		/// First coordinate.
		/// </summary>
		public float x { get; set; } 
		
		/// <summary>
		/// Second coordinate.
		/// </summary>
		public float y { get; set; } 
		
		/// <summary>
		/// Third coordinate.
		/// </summary>
		public float z { get; set; } 
		
		/// <summary>
		/// Fourth coordinate.
		/// </summary>
		public float w { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			x = reader.Read<float>();
			
			y = reader.Read<float>();
			
			z = reader.Read<float>();
			
			w = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(x);
			
			writer.Write(y);
			
			writer.Write(z);
			
			writer.Write(w);
			
		}
	}
	

}
