using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Stores the number of control points of a B-spline.
	///         
	/// </summary>
	public class NiBSplineBasisData : NiObject
	{
		/// <summary>
		/// The number of control points of the B-spline (number of frames of animation plus degree of B-spline minus one).
		/// </summary>
		public uint NumControlPoints { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumControlPoints = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumControlPoints);
			
		}
	}
	

}
