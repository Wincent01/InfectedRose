using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiPoint3Interpolator : NiKeyBasedInterpolator
	{
		/// <summary>
		/// Value when posed?  Value at time 0?
		/// </summary>
		public Vector3 Point3Value { get; set; } 
		
		/// <summary>
		/// Reference to NiPosData.
		/// </summary>
		public Ptr<NiPosData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Point3Value = new Vector3();
			Point3Value.Deserialize(reader);
			
			Data = reader.Read<Ptr<NiPosData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Point3Value);
			
			writer.Write(Data);
			
		}
	}
	

}
