using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Time controller for a path.
	///         
	/// </summary>
	public class NiPathController : NiTimeController
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Unknown, always 1?
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Unknown, often 0?
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown, often 0?
		/// </summary>
		public float UnknownFloat3 { get; set; } 
		
		/// <summary>
		/// Unknown, always 0?
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Path controller data index (position data). ?
		/// </summary>
		public Ptr<NiPosData> PosData { get; set; } 
		
		/// <summary>
		/// Path controller data index (float data). ?
		/// </summary>
		public Ptr<NiFloatData> FloatData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort2 = reader.Read<ushort>();
			
			UnknownInt1 = reader.Read<uint>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownShort = reader.Read<ushort>();
			
			PosData = reader.Read<Ptr<NiPosData>>();
			
			FloatData = reader.Read<Ptr<NiFloatData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort2);
			
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownShort);
			
			writer.Write(PosData);
			
			writer.Write(FloatData);
			
		}
	}
	

}
