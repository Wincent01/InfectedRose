using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         List of three vertex indices.
	///         
	/// </summary>
	public struct Triangle : IConstruct
	{
		/// <summary>
		/// First vertex index.
		/// </summary>
		public ushort v1 { get; set; } 
		
		/// <summary>
		/// Second vertex index.
		/// </summary>
		public ushort v2 { get; set; } 
		
		/// <summary>
		/// Third vertex index.
		/// </summary>
		public ushort v3 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			v1 = reader.Read<ushort>();
			
			v2 = reader.Read<ushort>();
			
			v3 = reader.Read<ushort>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(v1);
			
			writer.Write(v2);
			
			writer.Write(v3);
			
		}
	}
	

}
