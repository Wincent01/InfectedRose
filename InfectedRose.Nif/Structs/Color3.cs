using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A color without alpha (red, green, blue).
	///         
	/// </summary>
	public struct Color3 : IConstruct
	{
		/// <summary>
		/// Red color component.
		/// </summary>
		public float r { get; set; } 
		
		/// <summary>
		/// Green color component.
		/// </summary>
		public float g { get; set; } 
		
		/// <summary>
		/// Blue color component.
		/// </summary>
		public float b { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			r = reader.Read<float>();
			
			g = reader.Read<float>();
			
			b = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(r);
			
			writer.Write(g);
			
			writer.Write(b);
			
		}
	}
	

}
