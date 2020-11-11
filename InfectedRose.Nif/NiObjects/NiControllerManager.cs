using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown. Root of all controllers?
	///         
	/// </summary>
	public class NiControllerManager : NiTimeController
	{
		/// <summary>
		/// Designates whether animation sequences are cumulative?
		/// </summary>
		public bool Cumulative { get; set; } 
		
		/// <summary>
		/// The number of controller sequence objects.
		/// </summary>
		public uint NumControllerSequences { get; set; } 
		
		/// <summary>
		/// Refers to a list of NiControllerSequence object.
		/// </summary>
		public Ptr<NiControllerSequence>[] ControllerSequences { get; set; } 
		
		/// <summary>
		/// Refers to a NiDefaultAVObjectPalette.
		/// </summary>
		public Ptr<NiDefaultAVObjectPalette> ObjectPalette { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Cumulative = reader.Read<byte>() != 0;
			
			NumControllerSequences = reader.Read<uint>();
			
			ControllerSequences = new Ptr<NiControllerSequence>[NumControllerSequences];
			for (var i = 0; i < NumControllerSequences; i++)
			{
				ControllerSequences[i] = reader.Read<Ptr<NiControllerSequence>>();
			}
			
			ObjectPalette = reader.Read<Ptr<NiDefaultAVObjectPalette>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((byte) (Cumulative ? 1 : 0));
			
			writer.Write(NumControllerSequences);
			
			for (var i = 0; i < NumControllerSequences; i++)
			{
				writer.Write(ControllerSequences[i]);
			}
			
			writer.Write(ObjectPalette);
			
		}
	}
	

}
