using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Encapsulates a floodgate kernel that updates mesh particle alignment and transforms.
	///         
	/// </summary>
	public class NiPSSimulatorMeshAlignStep : NiPSSimulatorStep
	{
		/// <summary>
		/// The number of rotation keys.
		/// </summary>
		public byte NumRotationKeys { get; set; } 
		
		/// <summary>
		/// The particle rotation keys.
		/// </summary>
		public QuatKey<Quaternion>[] RotationKeys { get; set; } 
		
		/// <summary>
		/// The loop behavior for the rotation keys.
		/// </summary>
		public PSLoopBehavior RotationLoopBehavior { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumRotationKeys = reader.Read<byte>();
			
			RotationKeys = new QuatKey<Quaternion>[NumRotationKeys];
			for (var i = 0; i < NumRotationKeys; i++)
			{
				var value = new QuatKey<Quaternion>();
				value.Deserialize(reader);
				RotationKeys[i] = value;
			}
			
			RotationLoopBehavior = (PSLoopBehavior) reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumRotationKeys);
			
			for (var i = 0; i < NumRotationKeys; i++)
			{
				writer.Write(RotationKeys[i]);
			}
			
			writer.Write((uint) RotationLoopBehavior);
			
		}
	}
	

}
