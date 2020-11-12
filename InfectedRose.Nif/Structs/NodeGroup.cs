using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A group of NiNodes references.
	///         
	/// </summary>
	public class NodeGroup : IConstruct
	{
		/// <summary>
		/// Number of node references that follow.
		/// </summary>
		public uint NumNodes { get; set; } 
		
		/// <summary>
		/// The list of NiNode references.
		/// </summary>
		public Ptr<NiNode>[] Nodes { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumNodes = reader.Read<uint>();
			
			Nodes = new Ptr<NiNode>[NumNodes];
			for (var i = 0; i < NumNodes; i++)
			{
				Nodes[i] = reader.Read<Ptr<NiNode>>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumNodes);
			
			for (var i = 0; i < NumNodes; i++)
			{
				writer.Write(Nodes[i]);
			}
			
		}
	}
	

}
