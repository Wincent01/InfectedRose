using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.
	///         
	/// </summary>
	public class NiArkImporterExtraData : NiExtraData
	{
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Contains a string like "Gamebryo_1_1" or "4.1.0.12"
		/// </summary>
		public NiString ImporterName { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte[] UnknownBytes { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float[] UnknownFloats { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt1 = reader.Read<int>();
			
			ImporterName = new NiString();
			ImporterName.Deserialize(reader);
			
			UnknownBytes = new byte[13];
			for (var i = 0; i < 13; i++)
			{
				UnknownBytes[i] = reader.Read<byte>();
			}
			
			UnknownFloats = new float[7];
			for (var i = 0; i < 7; i++)
			{
				UnknownFloats[i] = reader.Read<float>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt1);
			
			writer.Write(ImporterName);
			
			for (var i = 0; i < 13; i++)
			{
				writer.Write(UnknownBytes[i]);
			}
			
			for (var i = 0; i < 7; i++)
			{
				writer.Write(UnknownFloats[i]);
			}
			
		}
	}
	

}
