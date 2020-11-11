using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown interpolator.
	///         
	/// </summary>
	public class NiPathInterpolator : NiKeyBasedInterpolator
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown. Zero.
		/// </summary>
		public ushort UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Links to NiPosData.
		/// </summary>
		public Ptr<NiPosData> PosData { get; set; } 
		
		/// <summary>
		/// Links to NiFloatData.
		/// </summary>
		public Ptr<NiFloatData> FloatData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<ushort>();
			
			UnknownInt = reader.Read<uint>();
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownShort2 = reader.Read<ushort>();
			
			PosData = reader.Read<Ptr<NiPosData>>();
			
			FloatData = reader.Read<Ptr<NiFloatData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
			writer.Write(UnknownInt);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownShort2);
			
			writer.Write(PosData);
			
			writer.Write(FloatData);
			
		}
	}
	

}
