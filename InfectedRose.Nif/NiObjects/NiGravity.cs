using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle modifier; applies a gravitational field on the particles.
	///         
	/// </summary>
	public class NiGravity : NiParticleModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// The strength/force of this gravity.
		/// </summary>
		public float Force { get; set; } 
		
		/// <summary>
		/// The force field's type.
		/// </summary>
		public FieldType Type { get; set; } 
		
		/// <summary>
		/// The position of the mass point relative to the particle system. (TODO: check for versions <= 3.1)
		/// </summary>
		public Vector3 Position { get; set; } 
		
		/// <summary>
		/// The direction of the applied acceleration.
		/// </summary>
		public Vector3 Direction { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFloat1 = reader.Read<float>();
			
			Force = reader.Read<float>();
			
			Type = (FieldType) reader.Read<uint>();
			
			Position = new Vector3();
			Position.Deserialize(reader);
			
			Direction = new Vector3();
			Direction.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownFloat1);
			
			writer.Write(Force);
			
			writer.Write((uint) Type);
			
			writer.Write(Position);
			
			writer.Write(Direction);
			
		}
	}
	

}
