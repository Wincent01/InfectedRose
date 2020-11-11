using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Encapsulates a floodgate kernel that simulates particle colliders.
	///         
	/// </summary>
	public class NiPSSimulatorCollidersStep : NiPSSimulatorStep
	{
		/// <summary>
		/// The number of colliders affecting the particle system.
		/// </summary>
		public uint NumColliders { get; set; } 
		
		/// <summary>
		/// The colliders affecting the particle system.
		/// </summary>
		public Ptr<NiObject>[] Colliders { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumColliders = reader.Read<uint>();
			
			Colliders = new Ptr<NiObject>[NumColliders];
			for (var i = 0; i < NumColliders; i++)
			{
				Colliders[i] = reader.Read<Ptr<NiObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumColliders);
			
			for (var i = 0; i < NumColliders; i++)
			{
				writer.Write(Colliders[i]);
			}
			
		}
	}
	

}
