using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Level of detail selector. Links to different levels of detail of the same model, used to switch a geometry at a specified distance.
	///         
	/// </summary>
	public class NiLODNode : NiSwitchNode
	{
		/// <summary>
		/// Refers to LOD level information, either distance or screen size based.
		/// </summary>
		public Ptr<NiLODData> LODLevelData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			LODLevelData = reader.Read<Ptr<NiLODData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(LODLevelData);
			
		}
	}
	

}
