using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiBSplineCompFloatInterpolator : NiBSplineFloatInterpolator
	{
		/// <summary>
		/// Base value when curve not defined.
		/// </summary>
		public float Base { get; set; } 
		
		/// <summary>
		/// Starting offset for the data. (USHRT_MAX for no data.)
		/// </summary>
		public uint Offset { get; set; } 
		
		/// <summary>
		/// Bias
		/// </summary>
		public float Bias { get; set; } 
		
		/// <summary>
		/// Multiplier
		/// </summary>
		public float Multiplier { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Base = reader.Read<float>();
			
			Offset = reader.Read<uint>();
			
			Bias = reader.Read<float>();
			
			Multiplier = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Base);
			
			writer.Write(Offset);
			
			writer.Write(Bias);
			
			writer.Write(Multiplier);
			
		}
	}
	

}
