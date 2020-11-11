using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.
	///         
	/// </summary>
	public class NiArkShaderExtraData : NiExtraData
	{
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public NiString UnknownString { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt = reader.Read<int>();
			
			UnknownString = new NiString();
			UnknownString.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt);
			
			writer.Write(UnknownString);
			
		}
	}
	

}
