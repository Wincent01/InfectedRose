using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An interpolator for a bool.
	///         
	/// </summary>
	public class NiBlendBoolInterpolator : NiBlendInterpolator
	{
		/// <summary>
		/// The interpolated bool?
		/// </summary>
		public byte BoolValue { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BoolValue = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(BoolValue);
			
		}
	}
	

}
