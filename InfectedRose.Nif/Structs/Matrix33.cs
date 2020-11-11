using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A 3x3 rotation matrix; M^T M=identity, det(M)=1.    Stored in OpenGL column-major format.
	///         
	/// </summary>
	public struct Matrix33 : IConstruct
	{
		/// <summary>
		/// Member 1,1 (top left)
		/// </summary>
		public float m11 { get; set; } 
		
		/// <summary>
		/// Member 2,1
		/// </summary>
		public float m21 { get; set; } 
		
		/// <summary>
		/// Member 3,1 (bottom left)
		/// </summary>
		public float m31 { get; set; } 
		
		/// <summary>
		/// Member 1,2
		/// </summary>
		public float m12 { get; set; } 
		
		/// <summary>
		/// Member 2,2
		/// </summary>
		public float m22 { get; set; } 
		
		/// <summary>
		/// Member 3,2
		/// </summary>
		public float m32 { get; set; } 
		
		/// <summary>
		/// Member 1,3 (top right)
		/// </summary>
		public float m13 { get; set; } 
		
		/// <summary>
		/// Member 2,3
		/// </summary>
		public float m23 { get; set; } 
		
		/// <summary>
		/// Member 3,3 (bottom left)
		/// </summary>
		public float m33 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			m11 = reader.Read<float>();
			
			m21 = reader.Read<float>();
			
			m31 = reader.Read<float>();
			
			m12 = reader.Read<float>();
			
			m22 = reader.Read<float>();
			
			m32 = reader.Read<float>();
			
			m13 = reader.Read<float>();
			
			m23 = reader.Read<float>();
			
			m33 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(m11);
			
			writer.Write(m21);
			
			writer.Write(m31);
			
			writer.Write(m12);
			
			writer.Write(m22);
			
			writer.Write(m32);
			
			writer.Write(m13);
			
			writer.Write(m23);
			
			writer.Write(m33);
			
		}
	}
	

}
