using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle modifier that adds rotations to particles.
	///         
	/// </summary>
	public class NiPSysRotationModifier : NiPSysModifier
	{
		/// <summary>
		/// The initial speed of rotation.
		/// </summary>
		public float InitialRotationSpeed { get; set; } 
		
		/// <summary>
		/// Adds a ranged randomness to rotation speed.
		/// </summary>
		public float InitialRotationSpeedVariation { get; set; } 
		
		/// <summary>
		/// Sets the intial angle for particles to be birthed in.
		/// </summary>
		public float InitialRotationAngle { get; set; } 
		
		/// <summary>
		/// Adds a random range to Initial angle.
		/// </summary>
		public float InitialRotationAngleVariation { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public bool RandomRotSpeedSign { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public bool RandomInitialAxis { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Vector3 InitialAxis { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			InitialRotationSpeed = reader.Read<float>();
			
			InitialRotationSpeedVariation = reader.Read<float>();
			
			InitialRotationAngle = reader.Read<float>();
			
			InitialRotationAngleVariation = reader.Read<float>();
			
			RandomRotSpeedSign = reader.Read<byte>() != 0;
			
			RandomInitialAxis = reader.Read<byte>() != 0;
			
			InitialAxis = new Vector3();
			InitialAxis.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(InitialRotationSpeed);
			
			writer.Write(InitialRotationSpeedVariation);
			
			writer.Write(InitialRotationAngle);
			
			writer.Write(InitialRotationAngleVariation);
			
			writer.Write((byte) (RandomRotSpeedSign ? 1 : 0));
			
			writer.Write((byte) (RandomInitialAxis ? 1 : 0));
			
			writer.Write(InitialAxis);
			
		}
	}
	

}
