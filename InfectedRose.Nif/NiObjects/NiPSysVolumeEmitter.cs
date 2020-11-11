using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An emitter that emits meshes?
	///         
	/// </summary>
	public abstract class NiPSysVolumeEmitter : NiPSysEmitter
	{
		/// <summary>
		/// Node parent of this modifier?
		/// </summary>
		public Ptr<NiNode> EmitterObject { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			EmitterObject = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(EmitterObject);
			
		}
	}
	

}
