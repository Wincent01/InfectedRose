using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle emitter?
	///         
	/// </summary>
	public abstract class NiPSysEmitter : NiPSysModifier
	{
		/// <summary>
		/// Speed / Inertia of particle movement.
		/// </summary>
		public float Speed { get; set; } 
		
		/// <summary>
		/// Adds an amount of randomness to Speed.
		/// </summary>
		public float SpeedVariation { get; set; } 
		
		/// <summary>
		/// Declination / First axis.
		/// </summary>
		public float Declination { get; set; } 
		
		/// <summary>
		/// Declination randomness / First axis.
		/// </summary>
		public float DeclinationVariation { get; set; } 
		
		/// <summary>
		/// Planar Angle / Second axis.
		/// </summary>
		public float PlanarAngle { get; set; } 
		
		/// <summary>
		/// Planar Angle randomness / Second axis .
		/// </summary>
		public float PlanarAngleVariation { get; set; } 
		
		/// <summary>
		/// Defines color of a birthed particle.
		/// </summary>
		public Color4 InitialColor { get; set; } 
		
		/// <summary>
		/// Size of a birthed particle.
		/// </summary>
		public float InitialRadius { get; set; } 
		
		/// <summary>
		/// Particle Radius randomness.
		/// </summary>
		public float RadiusVariation { get; set; } 
		
		/// <summary>
		/// Duration until a particle dies.
		/// </summary>
		public float LifeSpan { get; set; } 
		
		/// <summary>
		/// Adds randomness to Life Span.
		/// </summary>
		public float LifeSpanVariation { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Speed = reader.Read<float>();
			
			SpeedVariation = reader.Read<float>();
			
			Declination = reader.Read<float>();
			
			DeclinationVariation = reader.Read<float>();
			
			PlanarAngle = reader.Read<float>();
			
			PlanarAngleVariation = reader.Read<float>();
			
			InitialColor = new Color4();
			InitialColor.Deserialize(reader);
			
			InitialRadius = reader.Read<float>();
			
			RadiusVariation = reader.Read<float>();
			
			LifeSpan = reader.Read<float>();
			
			LifeSpanVariation = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Speed);
			
			writer.Write(SpeedVariation);
			
			writer.Write(Declination);
			
			writer.Write(DeclinationVariation);
			
			writer.Write(PlanarAngle);
			
			writer.Write(PlanarAngleVariation);
			
			writer.Write(InitialColor);
			
			writer.Write(InitialRadius);
			
			writer.Write(RadiusVariation);
			
			writer.Write(LifeSpan);
			
			writer.Write(LifeSpanVariation);
			
		}
	}
	

}
