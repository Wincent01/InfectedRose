using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Texture coordinates (u,v). As in OpenGL; image origin is in the lower left corner.
	///         
	/// </summary>
	public struct TexCoord : IConstruct
	{
		/// <summary>
		/// First coordinate.
		/// </summary>
		public float u { get; set; } 
		
		/// <summary>
		/// Second coordinate.
		/// </summary>
		public float v { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			u = reader.Read<float>();
			
			v = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(u);
			
			writer.Write(v);
			
		}
	}
	

}
