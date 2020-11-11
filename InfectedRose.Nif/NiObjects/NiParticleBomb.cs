using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle modifier.
	///         
	/// </summary>
	public class NiParticleBomb : NiParticleModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public float Decay { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float Duration { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float DeltaV { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float Start { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public DecayType DecayType { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public SymmetryType SymmetryType { get; set; } 
		
		/// <summary>
		/// The position of the mass point relative to the particle system?
		/// </summary>
		public Vector3 Position { get; set; } 
		
		/// <summary>
		/// The direction of the applied acceleration?
		/// </summary>
		public Vector3 Direction { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Decay = reader.Read<float>();
			
			Duration = reader.Read<float>();
			
			DeltaV = reader.Read<float>();
			
			Start = reader.Read<float>();
			
			DecayType = (DecayType) reader.Read<uint>();
			
			SymmetryType = (SymmetryType) reader.Read<uint>();
			
			Position = new Vector3();
			Position.Deserialize(reader);
			
			Direction = new Vector3();
			Direction.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Decay);
			
			writer.Write(Duration);
			
			writer.Write(DeltaV);
			
			writer.Write(Start);
			
			writer.Write((uint) DecayType);
			
			writer.Write((uint) SymmetryType);
			
			writer.Write(Position);
			
			writer.Write(Direction);
			
		}
	}
	

}
