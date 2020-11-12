using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A vector in 3D space (x,y,z).
	///         
	/// </summary>
	public class Vector3 : IConstruct
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
		
		public void Deserialize(BitReader reader)
		{
			x = reader.Read<float>();
			
			y = reader.Read<float>();
			
			z = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(x);
			
			writer.Write(y);
			
			writer.Write(z);
			
		}
	}
	

}
