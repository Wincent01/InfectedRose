using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Interpolates a point?
	///         
	/// </summary>
	public class NiBlendPoint3Interpolator : NiBlendInterpolator
	{
		/// <summary>
		/// The interpolated point?
		/// </summary>
		public Vector3 PointValue { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			PointValue = new Vector3();
			PointValue.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(PointValue);
			
		}
	}
	

}
