using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A color with alpha (red, green, blue, alpha).
	///         
	/// </summary>
	public struct Color4 : IConstruct
	{
		/// <summary>
		/// Red component.
		/// </summary>
		public float r { get; set; } 
		
		/// <summary>
		/// Green component.
		/// </summary>
		public float g { get; set; } 
		
		/// <summary>
		/// Blue component.
		/// </summary>
		public float b { get; set; } 
		
		/// <summary>
		/// Alpha.
		/// </summary>
		public float a { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			r = reader.Read<float>();
			
			g = reader.Read<float>();
			
			b = reader.Read<float>();
			
			a = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(r);
			
			writer.Write(g);
			
			writer.Write(b);
			
			writer.Write(a);
			
		}
	}
	

}
