using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A quaternion.
	///         
	/// </summary>
	public struct Quaternion : IConstruct
	{
		/// <summary>
		/// The w-coordinate.
		/// </summary>
		public float w { get; set; } 
		
		/// <summary>
		/// The x-coordinate.
		/// </summary>
		public float x { get; set; } 
		
		/// <summary>
		/// The y-coordinate.
		/// </summary>
		public float y { get; set; } 
		
		/// <summary>
		/// The z-coordinate.
		/// </summary>
		public float z { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			w = reader.Read<float>();
			
			x = reader.Read<float>();
			
			y = reader.Read<float>();
			
			z = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(w);
			
			writer.Write(x);
			
			writer.Write(y);
			
			writer.Write(z);
			
		}
	}
	

}
