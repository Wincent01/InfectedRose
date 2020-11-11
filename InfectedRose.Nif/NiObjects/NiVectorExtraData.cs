using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Extra vector data.
	///         
	/// </summary>
	public class NiVectorExtraData : NiExtraData
	{
		/// <summary>
		/// The vector data.
		/// </summary>
		public Vector3 VectorData { get; set; } 
		
		/// <summary>
		/// Not sure whether this comes before or after the vector data.
		/// </summary>
		public float UnknownFloat { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			VectorData = new Vector3();
			VectorData.Deserialize(reader);
			
			UnknownFloat = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(VectorData);
			
			writer.Write(UnknownFloat);
			
		}
	}
	

}
