using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Encapsulates a floodgate kernel that simulates particle forces.
	///         
	/// </summary>
	public class NiPSSimulatorForcesStep : NiPSSimulatorStep
	{
		/// <summary>
		/// The number of forces affecting the particle system.
		/// </summary>
		public uint NumForces { get; set; } 
		
		/// <summary>
		/// The forces affecting the particle system.
		/// </summary>
		public Ptr<NiObject>[] Forces { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumForces = reader.Read<uint>();
			
			Forces = new Ptr<NiObject>[NumForces];
			for (var i = 0; i < NumForces; i++)
			{
				Forces[i] = reader.Read<Ptr<NiObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumForces);
			
			for (var i = 0; i < NumForces; i++)
			{
				writer.Write(Forces[i]);
			}
			
		}
	}
	

}
