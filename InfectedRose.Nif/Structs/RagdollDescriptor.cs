using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This constraint defines a cone in which an object can rotate. The shape of the cone can be controlled in two (orthogonal) directions.
	///         
	/// </summary>
	public class RagdollDescriptor : IConstruct
	{
		/// <summary>
		/// Central directed axis of the cone in which the object can rotate. Orthogonal on Plane A.
		/// </summary>
		public Vector4 TwistA { get; set; } 
		
		/// <summary>
		/// Defines the orthogonal plane in which the body can move, the orthogonal directions in which the shape can be controlled (the direction orthogonal on this one and Twist A).
		/// </summary>
		public Vector4 PlaneA { get; set; } 
		
		/// <summary>
		/// Defines the orthogonal directions in which the shape can be controlled (namely in this direction, and in the direction orthogonal on this one and Twist A).
		/// </summary>
		public Vector4 MotorA { get; set; } 
		
		/// <summary>
		/// Point around which the object will rotate. Defines the orthogonal directions in which the shape can be controlled (namely in this direction, and in the direction orthogonal on this one and Twist A).
		/// </summary>
		public Vector4 PivotA { get; set; } 
		
		/// <summary>
		/// Central directed axis of the cone in which the object can rotate. Orthogonal on Plane B.
		/// </summary>
		public Vector4 TwistB { get; set; } 
		
		/// <summary>
		/// Defines the orthogonal plane in which the body can move, the orthogonal directions in which the shape can be controlled (the direction orthogonal on this one and Twist A).
		/// </summary>
		public Vector4 PlaneB { get; set; } 
		
		/// <summary>
		/// Defines the orthogonal directions in which the shape can be controlled (namely in this direction, and in the direction orthogonal on this one and Twist A).
		/// </summary>
		public Vector4 MotorB { get; set; } 
		
		/// <summary>
		/// Defines the orthogonal directions in which the shape can be controlled (namely in this direction, and in the direction orthogonal on this one and Twist A).
		/// </summary>
		public Vector4 PivotB { get; set; } 
		
		/// <summary>
		/// Maximum angle the object can rotate around the vector orthogonal on Plane A and Twist A relative to the Twist A vector. Note that Cone Min Angle is not stored, but is simply minus this angle.
		/// </summary>
		public float ConeMaxAngle { get; set; } 
		
		/// <summary>
		/// Minimum angle the object can rotate around Plane A, relative to Twist A.
		/// </summary>
		public float PlaneMinAngle { get; set; } 
		
		/// <summary>
		/// Maximum angle the object can rotate around Plane A, relative to Twist A.
		/// </summary>
		public float PlaneMaxAngle { get; set; } 
		
		/// <summary>
		/// Minimum angle the object can rotate around Twist A, relative to Plane A.
		/// </summary>
		public float TwistMinAngle { get; set; } 
		
		/// <summary>
		/// Maximum angle the object can rotate around Twist A, relative to Plane A.
		/// </summary>
		public float TwistMaxAngle { get; set; } 
		
		/// <summary>
		/// Maximum friction, typically 0 or 10. In Fallout 3, typically 100.
		/// </summary>
		public float MaxFriction { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public bool EnableMotor { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public MotorDescriptor Motor { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			TwistA = new Vector4();
			TwistA.Deserialize(reader);
			
			PlaneA = new Vector4();
			PlaneA.Deserialize(reader);
			
			MotorA = new Vector4();
			MotorA.Deserialize(reader);
			
			PivotA = new Vector4();
			PivotA.Deserialize(reader);
			
			TwistB = new Vector4();
			TwistB.Deserialize(reader);
			
			PlaneB = new Vector4();
			PlaneB.Deserialize(reader);
			
			MotorB = new Vector4();
			MotorB.Deserialize(reader);
			
			PivotB = new Vector4();
			PivotB.Deserialize(reader);
			
			ConeMaxAngle = reader.Read<float>();
			
			PlaneMinAngle = reader.Read<float>();
			
			PlaneMaxAngle = reader.Read<float>();
			
			TwistMinAngle = reader.Read<float>();
			
			TwistMaxAngle = reader.Read<float>();
			
			MaxFriction = reader.Read<float>();
			
			EnableMotor = reader.Read<byte>() != 0;
			
			if (EnableMotor)
			{
				Motor = new MotorDescriptor();
				Motor.Deserialize(reader);
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(TwistA);
			
			writer.Write(PlaneA);
			
			writer.Write(MotorA);
			
			writer.Write(PivotA);
			
			writer.Write(TwistB);
			
			writer.Write(PlaneB);
			
			writer.Write(MotorB);
			
			writer.Write(PivotB);
			
			writer.Write(ConeMaxAngle);
			
			writer.Write(PlaneMinAngle);
			
			writer.Write(PlaneMaxAngle);
			
			writer.Write(TwistMinAngle);
			
			writer.Write(TwistMaxAngle);
			
			writer.Write(MaxFriction);
			
			writer.Write((byte) (EnableMotor ? 1 : 0));
			
			if (EnableMotor)
			{
				writer.Write(Motor);
				
			}
		}
	}
	

}
