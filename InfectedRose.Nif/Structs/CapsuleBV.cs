using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Capsule Bounding Volume
	///         
	/// </summary>
	public class CapsuleBV : IConstruct
	{
		/// <summary>
		/// Center
		/// </summary>
		public Vector3 Center { get; set; } 
		
		/// <summary>
		/// Origin
		/// </summary>
		public Vector3 Origin { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Center = new Vector3();
			Center.Deserialize(reader);
			
			Origin = new Vector3();
			Origin.Deserialize(reader);
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Center);
			
			writer.Write(Origin);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
		}
	}
	

}
