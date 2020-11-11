using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A controller referring to a single interpolator.
	///         
	/// </summary>
	public abstract class NiSingleInterpController : NiInterpController
	{
		/// <summary>
		/// Link to interpolator.
		/// </summary>
		public Ptr<NiInterpolator> Interpolator { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Interpolator = reader.Read<Ptr<NiInterpolator>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Interpolator);
			
		}
	}
	

}
