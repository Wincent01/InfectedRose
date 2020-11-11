using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Root node in .kf files (version 10.0.1.0 and up).
	///         
	/// </summary>
	public class NiControllerSequence : NiSequence
	{
		/// <summary>
		/// Weight/priority of animation?
		/// </summary>
		public float Weight { get; set; } 
		
		/// <summary>
		/// Link to NiTextKeyExtraData. Replaces the other Text Keys field in versions 10.1.0.106 and up.
		/// </summary>
		public Ptr<NiTextKeyExtraData> TextKeys { get; set; } 
		
		/// <summary>
		/// Anim cycle type? Is part of "Flags" in other objects?
		/// </summary>
		public CycleType CycleType { get; set; } 
		
		/// <summary>
		/// The animation frequency.
		/// </summary>
		public float Frequency { get; set; } 
		
		/// <summary>
		/// The controller sequence start time?
		/// </summary>
		public float StartTime { get; set; } 
		
		/// <summary>
		/// The controller sequence stop time?
		/// </summary>
		public float StopTime { get; set; } 
		
		/// <summary>
		/// Refers to NiControllerManager which references this object, if any.
		/// </summary>
		public Ptr<NiControllerManager> Manager { get; set; } 
		
		/// <summary>
		/// Name of target node Controller acts on.
		/// </summary>
		public NiString TargetName { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		//public Ptr<BSAnimNotes> AnimNotes { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public short UnknownShort1 { get; set; } 
		
		/// <summary>
		/// Unknown, found in some Lazeska and Krazy Rain .KFs (seems to be 64 when present).
		/// </summary>
		public uint UnknownInt3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Weight = reader.Read<float>();
			
			TextKeys = reader.Read<Ptr<NiTextKeyExtraData>>();
			
			CycleType = (CycleType) reader.Read<uint>();
			
			Frequency = reader.Read<float>();
			
			StartTime = reader.Read<float>();
			
			StopTime = reader.Read<float>();
			
			Manager = reader.Read<Ptr<NiControllerManager>>();
			
			TargetName = new NiString();
			TargetName.Deserialize(reader);
			
			//AnimNotes = reader.Read<Ptr<BSAnimNotes>>();
			
			UnknownShort1 = reader.Read<short>();
			
			UnknownInt3 = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Weight);
			
			writer.Write(TextKeys);
			
			writer.Write((uint) CycleType);
			
			writer.Write(Frequency);
			
			writer.Write(StartTime);
			
			writer.Write(StopTime);
			
			writer.Write(Manager);
			
			writer.Write(TargetName);
			
			//writer.Write(AnimNotes);
			
			writer.Write(UnknownShort1);
			
			writer.Write(UnknownInt3);
			
		}
	}
	

}
