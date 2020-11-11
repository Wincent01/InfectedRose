using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXTransformDest : NiObject
	{
		/// <summary>
		/// Unknown. =1?
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// Unknown. =0
		/// </summary>
		public byte UnknownByte2 { get; set; } 
		
		/// <summary>
		/// Affected node?
		/// </summary>
		public Ptr<NiNode> Node { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownByte1 = reader.Read<byte>();
			
			UnknownByte2 = reader.Read<byte>();
			
			Node = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownByte1);
			
			writer.Write(UnknownByte2);
			
			writer.Write(Node);
			
		}
	}
	

}
