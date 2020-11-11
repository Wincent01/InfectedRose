using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A dynamic effect such as a light or environment map.
	///         
	/// </summary>
	public abstract class NiDynamicEffect : NiAVObject
	{
		/// <summary>
		/// Turns effect on and off?  Switches list to list of unaffected nodes?
		/// </summary>
		public bool SwitchState { get; set; } 
		
		/// <summary>
		/// The number of affected nodes referenced.
		/// </summary>
		public uint NumAffectedNodes { get; set; } 
		
		/// <summary>
		/// The list of affected nodes?
		/// </summary>
		public Ptr<NiAVObject>[] AffectedNodes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			SwitchState = reader.Read<byte>() != 0;
			
			NumAffectedNodes = reader.Read<uint>();
			
			AffectedNodes = new Ptr<NiAVObject>[NumAffectedNodes];
			for (var i = 0; i < NumAffectedNodes; i++)
			{
				AffectedNodes[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((byte) (SwitchState ? 1 : 0));
			
			writer.Write(NumAffectedNodes);
			
			for (var i = 0; i < NumAffectedNodes; i++)
			{
				writer.Write(AffectedNodes[i]);
			}
			
		}
	}
	

}
