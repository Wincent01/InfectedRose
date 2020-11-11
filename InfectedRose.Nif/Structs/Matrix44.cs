using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A 4x4 transformation matrix.
	///         
	/// </summary>
	public struct Matrix44 : IConstruct
	{
		/// <summary>
		/// The (1,1) element.
		/// </summary>
		public float m11 { get; set; } 
		
		/// <summary>
		/// The (2,1) element.
		/// </summary>
		public float m21 { get; set; } 
		
		/// <summary>
		/// The (3,1) element.
		/// </summary>
		public float m31 { get; set; } 
		
		/// <summary>
		/// The (4,1) element.
		/// </summary>
		public float m41 { get; set; } 
		
		/// <summary>
		/// The (1,2) element.
		/// </summary>
		public float m12 { get; set; } 
		
		/// <summary>
		/// The (2,2) element.
		/// </summary>
		public float m22 { get; set; } 
		
		/// <summary>
		/// The (3,2) element.
		/// </summary>
		public float m32 { get; set; } 
		
		/// <summary>
		/// The (4,2) element.
		/// </summary>
		public float m42 { get; set; } 
		
		/// <summary>
		/// The (1,3) element.
		/// </summary>
		public float m13 { get; set; } 
		
		/// <summary>
		/// The (2,3) element.
		/// </summary>
		public float m23 { get; set; } 
		
		/// <summary>
		/// The (3,3) element.
		/// </summary>
		public float m33 { get; set; } 
		
		/// <summary>
		/// The (4,3) element.
		/// </summary>
		public float m43 { get; set; } 
		
		/// <summary>
		/// The (1,4) element.
		/// </summary>
		public float m14 { get; set; } 
		
		/// <summary>
		/// The (2,4) element.
		/// </summary>
		public float m24 { get; set; } 
		
		/// <summary>
		/// The (3,4) element.
		/// </summary>
		public float m34 { get; set; } 
		
		/// <summary>
		/// The (4,4) element.
		/// </summary>
		public float m44 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			m11 = reader.Read<float>();
			
			m21 = reader.Read<float>();
			
			m31 = reader.Read<float>();
			
			m41 = reader.Read<float>();
			
			m12 = reader.Read<float>();
			
			m22 = reader.Read<float>();
			
			m32 = reader.Read<float>();
			
			m42 = reader.Read<float>();
			
			m13 = reader.Read<float>();
			
			m23 = reader.Read<float>();
			
			m33 = reader.Read<float>();
			
			m43 = reader.Read<float>();
			
			m14 = reader.Read<float>();
			
			m24 = reader.Read<float>();
			
			m34 = reader.Read<float>();
			
			m44 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(m11);
			
			writer.Write(m21);
			
			writer.Write(m31);
			
			writer.Write(m41);
			
			writer.Write(m12);
			
			writer.Write(m22);
			
			writer.Write(m32);
			
			writer.Write(m42);
			
			writer.Write(m13);
			
			writer.Write(m23);
			
			writer.Write(m33);
			
			writer.Write(m43);
			
			writer.Write(m14);
			
			writer.Write(m24);
			
			writer.Write(m34);
			
			writer.Write(m44);
			
		}
	}
	

}
