using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown node.  Found in Loki.
	///         
	/// </summary>
	public class NiSortAdjustNode : NiNode
	{
		/// <summary>
		/// Sorting
		/// </summary>
		public SortingMode SortingMode { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			SortingMode = (SortingMode) reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((uint) SortingMode);
			
		}
	}
	

}
