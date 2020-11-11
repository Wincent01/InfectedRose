using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An interpolator for storing transform keyframes via a compressed
	///         B-spline (that is, using shorts rather than floats in the B-spline
	///         data).
	///         
	/// </summary>
	public class NiBSplineCompTransformInterpolator : NiBSplineTransformInterpolator
	{
		/// <summary>
		/// Translation Bias
		/// </summary>
		public float TranslationBias { get; set; } 
		
		/// <summary>
		/// Translation Multiplier
		/// </summary>
		public float TranslationMultiplier { get; set; } 
		
		/// <summary>
		/// Rotation Bias
		/// </summary>
		public float RotationBias { get; set; } 
		
		/// <summary>
		/// Rotation Multiplier
		/// </summary>
		public float RotationMultiplier { get; set; } 
		
		/// <summary>
		/// Scale Bias
		/// </summary>
		public float ScaleBias { get; set; } 
		
		/// <summary>
		/// Scale Multiplier
		/// </summary>
		public float ScaleMultiplier { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			TranslationBias = reader.Read<float>();
			
			TranslationMultiplier = reader.Read<float>();
			
			RotationBias = reader.Read<float>();
			
			RotationMultiplier = reader.Read<float>();
			
			ScaleBias = reader.Read<float>();
			
			ScaleMultiplier = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(TranslationBias);
			
			writer.Write(TranslationMultiplier);
			
			writer.Write(RotationBias);
			
			writer.Write(RotationMultiplier);
			
			writer.Write(ScaleBias);
			
			writer.Write(ScaleMultiplier);
			
		}
	}
	

}
