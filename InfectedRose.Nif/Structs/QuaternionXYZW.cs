using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A quaternion as it appears in the havok objects.
	///         
	/// </summary>
	public struct QuaternionXYZW : IConstruct
	{
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
		
		/// <summary>
		/// The w-coordinate.
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
