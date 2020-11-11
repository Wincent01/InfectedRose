using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         List of strings; for example, a list of all bone names.
	///         
	/// </summary>
	public class NiStringsExtraData : NiExtraData
	{
		/// <summary>
		/// Number of strings.
		/// </summary>
		public uint NumStrings { get; set; } 
		
		/// <summary>
		/// The strings.
		/// </summary>
		public SizedString[] Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumStrings = reader.Read<uint>();
			
			Data = new SizedString[NumStrings];
			for (var i = 0; i < NumStrings; i++)
			{
				var value = new SizedString();
				value.Deserialize(reader);
				Data[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumStrings);
			
			for (var i = 0; i < NumStrings; i++)
			{
				writer.Write(Data[i]);
			}
			
		}
	}
	

}
