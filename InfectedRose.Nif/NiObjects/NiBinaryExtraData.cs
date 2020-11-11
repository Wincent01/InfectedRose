using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Binary extra data object. Used to store tangents and bitangents in Oblivion.
	///         
	/// </summary>
	public class NiBinaryExtraData : NiExtraData
	{
		/// <summary>
		/// The binary data.
		/// </summary>
		public ByteArray BinaryData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BinaryData = new ByteArray();
			BinaryData.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(BinaryData);
			
		}
	}
	

}
