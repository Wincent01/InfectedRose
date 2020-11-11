using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A controller that interpolates point 3 data?
	///         
	/// </summary>
	public abstract class NiPoint3InterpController : NiSingleInterpController
	{
		/// <summary>
		/// Selects which color to control.
		/// </summary>
		public TargetColor TargetColor { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			TargetColor = (TargetColor) reader.Read<ushort>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((ushort) TargetColor);
			
		}
	}
	

}
