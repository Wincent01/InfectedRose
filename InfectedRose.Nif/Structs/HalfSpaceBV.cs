using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class HalfSpaceBV : IConstruct
	{
		/// <summary>
		/// Normal
		/// </summary>
		public Vector3 Normal { get; set; } 
		
		/// <summary>
		/// Center
		/// </summary>
		public Vector3 Center { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Normal = new Vector3();
			Normal.Deserialize(reader);
			
			Center = new Vector3();
			Center.Deserialize(reader);
			
			UnknownFloat1 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Normal);
			
			writer.Write(Center);
			
			writer.Write(UnknownFloat1);
			
		}
	}
	

}
