using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiBoolInterpolator : NiKeyBasedInterpolator
	{
		/// <summary>
		/// Value when posed?  At time 0?
		/// </summary>
		public bool BoolValue { get; set; } 
		
		/// <summary>
		/// Refers to a NiBoolData object.
		/// </summary>
		public Ptr<NiBoolData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BoolValue = reader.Read<byte>() != 0;
			
			Data = reader.Read<Ptr<NiBoolData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((byte) (BoolValue ? 1 : 0));
			
			writer.Write(Data);
			
		}
	}
	

}
