using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiParticleRotation : NiParticleModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte RandomInitialAxis { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Vector3 InitialAxis { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float RotationSpeed { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			RandomInitialAxis = reader.Read<byte>();
			
			InitialAxis = new Vector3();
			InitialAxis.Deserialize(reader);
			
			RotationSpeed = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(RandomInitialAxis);
			
			writer.Write(InitialAxis);
			
			writer.Write(RotationSpeed);
			
		}
	}
	

}
