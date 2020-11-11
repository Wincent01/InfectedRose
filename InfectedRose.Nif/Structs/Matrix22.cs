using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A 2x2 matrix of float values.  Stored in OpenGL column-major format.
	///         
	/// </summary>
	public struct Matrix22 : IConstruct
	{
		/// <summary>
		/// Member 1,1 (top left)
		/// </summary>
		public float m11 { get; set; } 
		
		/// <summary>
		/// Member 2,1 (bottom left)
		/// </summary>
		public float m21 { get; set; } 
		
		/// <summary>
		/// Member 1,2 (top right)
		/// </summary>
		public float m12 { get; set; } 
		
		/// <summary>
		/// Member 2,2 (bottom right)
		/// </summary>
		public float m22 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			m11 = reader.Read<float>();
			
			m21 = reader.Read<float>();
			
			m12 = reader.Read<float>();
			
			m22 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(m11);
			
			writer.Write(m21);
			
			writer.Write(m12);
			
			writer.Write(m22);
			
		}
	}
	

}
