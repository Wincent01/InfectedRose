using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The mesh modifier that performs all particle system simulation.
	///         
	/// </summary>
	public class NiPSSimulator : NiMeshModifier
	{
		/// <summary>
		/// The number of simulation steps in this modifier.
		/// </summary>
		public uint NumSimulationSteps { get; set; } 
		
		/// <summary>
		/// Links to the simulation steps.
		/// </summary>
		public Ptr<NiPSSimulatorStep>[] SimulationSteps { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumSimulationSteps = reader.Read<uint>();
			
			SimulationSteps = new Ptr<NiPSSimulatorStep>[NumSimulationSteps];
			for (var i = 0; i < NumSimulationSteps; i++)
			{
				SimulationSteps[i] = reader.Read<Ptr<NiPSSimulatorStep>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumSimulationSteps);
			
			for (var i = 0; i < NumSimulationSteps; i++)
			{
				writer.Write(SimulationSteps[i]);
			}
			
		}
	}
	

}
