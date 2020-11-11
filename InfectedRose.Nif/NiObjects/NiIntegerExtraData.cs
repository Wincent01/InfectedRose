using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Extra integer data.
	///         
	/// </summary>
	public class NiIntegerExtraData : NiExtraData
	{
		/// <summary>
		/// The value of the extra data.
		/// </summary>
		public uint IntegerData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			IntegerData = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(IntegerData);
			
		}
	}
	

}
