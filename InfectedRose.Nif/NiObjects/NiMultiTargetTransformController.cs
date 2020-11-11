using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiMultiTargetTransformController : NiInterpController
	{
		/// <summary>
		/// The number of target pointers that follow.
		/// </summary>
		public ushort NumExtraTargets { get; set; } 
		
		/// <summary>
		/// NiNode Targets to be controlled.
		/// </summary>
		public Ptr<NiAVObject>[] ExtraTargets { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumExtraTargets = reader.Read<ushort>();
			
			ExtraTargets = new Ptr<NiAVObject>[NumExtraTargets];
			for (var i = 0; i < NumExtraTargets; i++)
			{
				ExtraTargets[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumExtraTargets);
			
			for (var i = 0; i < NumExtraTargets; i++)
			{
				writer.Write(ExtraTargets[i]);
			}
			
		}
	}
	

}
