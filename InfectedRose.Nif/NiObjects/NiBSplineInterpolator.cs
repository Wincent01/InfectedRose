using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         For interpolators storing data via a B-spline.
	///         
	/// </summary>
	public abstract class NiBSplineInterpolator : NiInterpolator
	{
		/// <summary>
		/// Animation start time.
		/// </summary>
		public float StartTime { get; set; } 
		
		/// <summary>
		/// Animation stop time.
		/// </summary>
		public float StopTime { get; set; } 
		
		/// <summary>
		/// Refers to NiBSplineData.
		/// </summary>
		public Ptr<NiBSplineData> SplineData { get; set; } 
		
		/// <summary>
		/// Refers to NiBSPlineBasisData.
		/// </summary>
		public Ptr<NiBSplineBasisData> BasisData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			StartTime = reader.Read<float>();
			
			StopTime = reader.Read<float>();
			
			SplineData = reader.Read<Ptr<NiBSplineData>>();
			
			BasisData = reader.Read<Ptr<NiBSplineBasisData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(StartTime);
			
			writer.Write(StopTime);
			
			writer.Write(SplineData);
			
			writer.Write(BasisData);
			
		}
	}
	

}
