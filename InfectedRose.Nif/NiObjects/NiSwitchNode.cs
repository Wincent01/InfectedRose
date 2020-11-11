using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A node used to switch between branches, such as for LOD levels?
	///         
	/// </summary>
	public class NiSwitchNode : NiNode
	{
		/// <summary>
		/// Flags
		/// </summary>
		public ushort UnknownFlags1 { get; set; } 
		
		/// <summary>
		/// Index?
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFlags1 = reader.Read<ushort>();
			
			UnknownInt1 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownFlags1);
			
			writer.Write(UnknownInt1);
			
		}
	}
	

}
