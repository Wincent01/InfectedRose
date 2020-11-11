using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A generic particle system time controller object.
	///         
	/// </summary>
	public class NiParticleSystemController : NiTimeController
	{
		/// <summary>
		/// Particle speed
		/// </summary>
		public float Speed { get; set; } 
		
		/// <summary>
		/// Particle random speed modifier
		/// </summary>
		public float SpeedRandom { get; set; } 
		
		/// <summary>
		/// 
		///             vertical emit direction [radians]
		///             0.0 : up
		///             1.6 : horizontal
		///             3.1416 : down
		///         
		/// </summary>
		public float VerticalDirection { get; set; } 
		
		/// <summary>
		/// emitter's vertical opening angle [radians]
		/// </summary>
		public float VerticalAngle { get; set; } 
		
		/// <summary>
		/// horizontal emit direction
		/// </summary>
		public float HorizontalDirection { get; set; } 
		
		/// <summary>
		/// emitter's horizontal opening angle
		/// </summary>
		public float HorizontalAngle { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Vector3 UnknownNormal { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public Color4 UnknownColor { get; set; } 
		
		/// <summary>
		/// Particle size
		/// </summary>
		public float Size { get; set; } 
		
		/// <summary>
		/// Particle emit start time
		/// </summary>
		public float EmitStartTime { get; set; } 
		
		/// <summary>
		/// Particle emit stop time
		/// </summary>
		public float EmitStopTime { get; set; } 
		
		/// <summary>
		/// Unknown byte, (=0)
		/// </summary>
		public byte UnknownByte { get; set; } 
		
		/// <summary>
		/// Particle emission rate (particles per second)
		/// </summary>
		public float EmitRate { get; set; } 
		
		/// <summary>
		/// Particle lifetime
		/// </summary>
		public float Lifetime { get; set; } 
		
		/// <summary>
		/// Particle lifetime random modifier
		/// </summary>
		public float LifetimeRandom { get; set; } 
		
		/// <summary>
		/// Bit 0: Emit Rate toggle bit (0 = auto adjust, 1 = use Emit Rate value)
		/// </summary>
		public ushort EmitFlags { get; set; } 
		
		/// <summary>
		/// Particle random start translation vector
		/// </summary>
		public Vector3 StartRandom { get; set; } 
		
		/// <summary>
		/// This index targets the particle emitter object (TODO: find out what type of object this refers to).
		/// </summary>
		public Ptr<NiObject> Emitter { get; set; } 
		
		/// <summary>
		/// ? short=0 ?
		/// </summary>
		public ushort UnknownShort2 { get; set; } 
		
		/// <summary>
		/// ? float=1.0 ?
		/// </summary>
		public float UnknownFloat13 { get; set; } 
		
		/// <summary>
		/// ? int=1 ?
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// ? int=0 ?
		/// </summary>
		public uint UnknownInt2 { get; set; } 
		
		/// <summary>
		/// ? short=0 ?
		/// </summary>
		public ushort UnknownShort3 { get; set; } 
		
		/// <summary>
		/// Size of the following array. (Maximum number of simultaneous active particles)
		/// </summary>
		public ushort NumParticles { get; set; } 
		
		/// <summary>
		/// Number of valid entries in the following array. (Number of active particles at the time the system was saved)
		/// </summary>
		public ushort NumValid { get; set; } 
		
		/// <summary>
		/// Individual particle modifiers?
		/// </summary>
		public Particle[] Particles { get; set; } 
		
		/// <summary>
		/// unknown int (=0xffffffff)
		/// </summary>
		public Ptr<NiObject> UnknownLink { get; set; } 
		
		/// <summary>
		/// Link to some optional particle modifiers (NiGravity, NiParticleGrowFade, NiParticleBomb, ...)
		/// </summary>
		public Ptr<NiParticleModifier> ParticleExtra { get; set; } 
		
		/// <summary>
		/// Unknown int (=0xffffffff)
		/// </summary>
		public Ptr<NiObject> UnknownLink2 { get; set; } 
		
		/// <summary>
		/// Trailing null byte
		/// </summary>
		public byte Trailer { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Speed = reader.Read<float>();
			
			SpeedRandom = reader.Read<float>();
			
			VerticalDirection = reader.Read<float>();
			
			VerticalAngle = reader.Read<float>();
			
			HorizontalDirection = reader.Read<float>();
			
			HorizontalAngle = reader.Read<float>();
			
			UnknownNormal = new Vector3();
			UnknownNormal.Deserialize(reader);
			
			UnknownColor = new Color4();
			UnknownColor.Deserialize(reader);
			
			Size = reader.Read<float>();
			
			EmitStartTime = reader.Read<float>();
			
			EmitStopTime = reader.Read<float>();
			
			UnknownByte = reader.Read<byte>();
			
			EmitRate = reader.Read<float>();
			
			Lifetime = reader.Read<float>();
			
			LifetimeRandom = reader.Read<float>();
			
			EmitFlags = reader.Read<ushort>();
			
			StartRandom = new Vector3();
			StartRandom.Deserialize(reader);
			
			Emitter = reader.Read<Ptr<NiObject>>();
			
			UnknownShort2 = reader.Read<ushort>();
			
			UnknownFloat13 = reader.Read<float>();
			
			UnknownInt1 = reader.Read<uint>();
			
			UnknownInt2 = reader.Read<uint>();
			
			UnknownShort3 = reader.Read<ushort>();
			
			NumParticles = reader.Read<ushort>();
			
			NumValid = reader.Read<ushort>();
			
			Particles = new Particle[NumParticles];
			for (var i = 0; i < NumParticles; i++)
			{
				var value = new Particle();
				value.Deserialize(reader);
				Particles[i] = value;
			}
			
			UnknownLink = reader.Read<Ptr<NiObject>>();
			
			ParticleExtra = reader.Read<Ptr<NiParticleModifier>>();
			
			UnknownLink2 = reader.Read<Ptr<NiObject>>();
			
			Trailer = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Speed);
			
			writer.Write(SpeedRandom);
			
			writer.Write(VerticalDirection);
			
			writer.Write(VerticalAngle);
			
			writer.Write(HorizontalDirection);
			
			writer.Write(HorizontalAngle);
			
			writer.Write(UnknownNormal);
			
			writer.Write(UnknownColor);
			
			writer.Write(Size);
			
			writer.Write(EmitStartTime);
			
			writer.Write(EmitStopTime);
			
			writer.Write(UnknownByte);
			
			writer.Write(EmitRate);
			
			writer.Write(Lifetime);
			
			writer.Write(LifetimeRandom);
			
			writer.Write(EmitFlags);
			
			writer.Write(StartRandom);
			
			writer.Write(Emitter);
			
			writer.Write(UnknownShort2);
			
			writer.Write(UnknownFloat13);
			
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownShort3);
			
			writer.Write(NumParticles);
			
			writer.Write(NumValid);
			
			for (var i = 0; i < NumParticles; i++)
			{
				writer.Write(Particles[i]);
			}
			
			writer.Write(UnknownLink);
			
			writer.Write(ParticleExtra);
			
			writer.Write(UnknownLink2);
			
			writer.Write(Trailer);
			
		}
	}
	

}
