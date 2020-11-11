using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A sphere.
	///         
	/// </summary>
	public struct SphereBV : IConstruct
	{
		/// <summary>
		/// The sphere's center.
		/// </summary>
		public Vector3 Center { get; set; } 
		
		/// <summary>
		/// The sphere's radius.
		/// </summary>
		public float Radius { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Center = new Vector3();
			Center.Deserialize(reader);
			
			Radius = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Center);
			
			writer.Write(Radius);
			
		}
	}
	

}
