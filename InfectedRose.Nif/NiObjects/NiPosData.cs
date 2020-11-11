using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Position data.
	///         
	/// </summary>
	public class NiPosData : NiObject
	{
		/// <summary>
		/// The position keys.
		/// </summary>
		public KeyGroup<Vector3> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = new KeyGroup<Vector3>();
			Data.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
