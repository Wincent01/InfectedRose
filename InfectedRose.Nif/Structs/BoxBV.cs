using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Box Bounding Volume
	///         
	/// </summary>
	public struct BoxBV : IConstruct
	{
		/// <summary>
		/// Center
		/// </summary>
		public Vector3 Center { get; set; } 
		
		/// <summary>
		/// Axis
		/// </summary>
		public Vector3[] Axis { get; set; } 
		
		/// <summary>
		/// Extent
		/// </summary>
		public float[] Extent { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Center = new Vector3();
			Center.Deserialize(reader);
			
			Axis = new Vector3[3];
			for (var i = 0; i < 3; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Axis[i] = value;
			}
			
			Extent = new float[3];
			for (var i = 0; i < 3; i++)
			{
				Extent[i] = reader.Read<float>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Center);
			
			for (var i = 0; i < 3; i++)
			{
				writer.Write(Axis[i]);
			}
			
			for (var i = 0; i < 3; i++)
			{
				writer.Write(Extent[i]);
			}
			
		}
	}
	

}
