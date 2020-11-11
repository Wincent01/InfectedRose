using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An interpolator for a float.
	///         
	/// </summary>
	public class NiBlendFloatInterpolator : NiBlendInterpolator
	{
		/// <summary>
		/// The interpolated float?
		/// </summary>
		public float FloatValue { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			FloatValue = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(FloatValue);
			
		}
	}
	

}
