using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public abstract class NiBSplinePoint3Interpolator : NiBSplineInterpolator
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public float[] UnknownFloats { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFloats = new float[6];
			for (var i = 0; i < 6; i++)
			{
				UnknownFloats[i] = reader.Read<float>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 6; i++)
			{
				writer.Write(UnknownFloats[i]);
			}
			
		}
	}
	

}
