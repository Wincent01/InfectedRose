using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Time controller for geometry morphing.
	///         
	/// </summary>
	public class NiGeomMorpherController : NiInterpController
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort ExtraFlags { get; set; } 
		
		/// <summary>
		/// Geometry morphing data index.
		/// </summary>
		public Ptr<NiMorphData> Data { get; set; } 
		
		/// <summary>
		/// Always Update
		/// </summary>
		public byte AlwaysUpdate { get; set; } 
		
		/// <summary>
		/// The number of interpolator objects.
		/// </summary>
		public uint NumInterpolators { get; set; } 
		
		/// <summary>
		/// Weighted Interpolators?
		/// </summary>
		public MorphWeight[] InterpolatorWeights { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ExtraFlags = reader.Read<ushort>();
			
			Data = reader.Read<Ptr<NiMorphData>>();
			
			AlwaysUpdate = reader.Read<byte>();
			
			NumInterpolators = reader.Read<uint>();
			
			InterpolatorWeights = new MorphWeight[NumInterpolators];
			for (var i = 0; i < NumInterpolators; i++)
			{
				var value = new MorphWeight();
				value.Deserialize(reader);
				InterpolatorWeights[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ExtraFlags);
			
			writer.Write(Data);
			
			writer.Write(AlwaysUpdate);
			
			writer.Write(NumInterpolators);
			
			for (var i = 0; i < NumInterpolators; i++)
			{
				writer.Write(InterpolatorWeights[i]);
			}
			
		}
	}
	

}
