using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         B-spline data points as floats, or as shorts for compressed B-splines.
	///         
	/// </summary>
	public class NiBSplineData : NiObject
	{
		/// <summary>
		/// Number of Float Data Points
		/// </summary>
		public uint NumFloatControlPoints { get; set; } 
		
		/// <summary>
		/// Float values representing the control data.
		/// </summary>
		public float[] FloatControlPoints { get; set; } 
		
		/// <summary>
		/// Number of Short Data Points
		/// </summary>
		public uint NumShortControlPoints { get; set; } 
		
		/// <summary>
		/// Signed shorts representing the data from 0 to 1 (scaled by SHRT_MAX).
		/// </summary>
		public short[] ShortControlPoints { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumFloatControlPoints = reader.Read<uint>();
			
			FloatControlPoints = new float[NumFloatControlPoints];
			for (var i = 0; i < NumFloatControlPoints; i++)
			{
				FloatControlPoints[i] = reader.Read<float>();
			}
			
			NumShortControlPoints = reader.Read<uint>();
			
			ShortControlPoints = new short[NumShortControlPoints];
			for (var i = 0; i < NumShortControlPoints; i++)
			{
				ShortControlPoints[i] = reader.Read<short>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumFloatControlPoints);
			
			for (var i = 0; i < NumFloatControlPoints; i++)
			{
				writer.Write(FloatControlPoints[i]);
			}
			
			writer.Write(NumShortControlPoints);
			
			for (var i = 0; i < NumShortControlPoints; i++)
			{
				writer.Write(ShortControlPoints[i]);
			}
			
		}
	}
	

}
