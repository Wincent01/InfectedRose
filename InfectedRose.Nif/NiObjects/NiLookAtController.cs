using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown. Start time is 3.4e+38 and stop time is -3.4e+38.
	///         
	/// </summary>
	public class NiLookAtController : NiTimeController
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort Unknown1 { get; set; } 
		
		/// <summary>
		/// Link to the node to look at?
		/// </summary>
		public Ptr<NiNode> LookAtNode { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = reader.Read<ushort>();
			
			LookAtNode = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown1);
			
			writer.Write(LookAtNode);
			
		}
	}
	

}
