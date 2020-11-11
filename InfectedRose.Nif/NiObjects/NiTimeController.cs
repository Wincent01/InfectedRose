using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A generic time controller object.
	///         
	/// </summary>
	public abstract class NiTimeController : NiObject
	{
		/// <summary>
		/// Index of the next controller.
		/// </summary>
		public Ptr<NiTimeController> NextController { get; set; } 
		
		/// <summary>
		/// 
		///             Controller flags (usually 0x000C). Probably controls loops.
		///             Bit 0 : Anim type, 0=APP_TIME 1=APP_INIT
		///             Bit 1-2 : Cycle type  00=Loop 01=Reverse 10=Loop
		///             Bit 3 : Active
		///             Bit 4 : Play backwards
		///         
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Frequency (is usually 1.0).
		/// </summary>
		public float Frequency { get; set; } 
		
		/// <summary>
		/// Phase (usually 0.0).
		/// </summary>
		public float Phase { get; set; } 
		
		/// <summary>
		/// Controller start time.
		/// </summary>
		public float StartTime { get; set; } 
		
		/// <summary>
		/// Controller stop time.
		/// </summary>
		public float StopTime { get; set; } 
		
		/// <summary>
		/// Controller target (object index of the first controllable ancestor of this object).
		/// </summary>
		public Ptr<NiObjectNET> Target { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NextController = reader.Read<Ptr<NiTimeController>>();
			
			Flags = reader.Read<ushort>();
			
			Frequency = reader.Read<float>();
			
			Phase = reader.Read<float>();
			
			StartTime = reader.Read<float>();
			
			StopTime = reader.Read<float>();
			
			Target = reader.Read<Ptr<NiObjectNET>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NextController);
			
			writer.Write(Flags);
			
			writer.Write(Frequency);
			
			writer.Write(Phase);
			
			writer.Write(StartTime);
			
			writer.Write(StopTime);
			
			writer.Write(Target);
			
		}
	}
	

}
