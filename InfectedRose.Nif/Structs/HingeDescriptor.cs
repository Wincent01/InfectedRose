using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///     	This constraint allows rotation about a specified axis. 
	///     	
	///         
	/// </summary>
	public class HingeDescriptor : IConstruct
	{
		/// <summary>
		/// Axis of rotation.
		/// </summary>
		public Vector4 AxleA { get; set; } 
		
		/// <summary>
		/// Vector in the rotation plane which defines the zero angle.
		/// </summary>
		public Vector4 Perp2AxleInA1 { get; set; } 
		
		/// <summary>
		/// Vector in the rotation plane, orthogonal on the previous one, which defines the positive direction of rotation. This is always the vector product of Axle A and Perp2 Axle In A1.
		/// </summary>
		public Vector4 Perp2AxleInA2 { get; set; } 
		
		/// <summary>
		/// Pivot point around which the object will rotate.
		/// </summary>
		public Vector4 PivotA { get; set; } 
		
		/// <summary>
		/// Axle A in second entity coordinate system.
		/// </summary>
		public Vector4 AxleB { get; set; } 
		
		/// <summary>
		/// Perp2 Axle In A1 in second entity coordinate system.
		/// </summary>
		public Vector4 Perp2AxleInB1 { get; set; } 
		
		/// <summary>
		/// Perp2 Axle In A2 in second entity coordinate system.
		/// </summary>
		public Vector4 Perp2AxleInB2 { get; set; } 
		
		/// <summary>
		/// Pivot A in second entity coordinate system.
		/// </summary>
		public Vector4 PivotB { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			AxleA = new Vector4();
			AxleA.Deserialize(reader);
			
			Perp2AxleInA1 = new Vector4();
			Perp2AxleInA1.Deserialize(reader);
			
			Perp2AxleInA2 = new Vector4();
			Perp2AxleInA2.Deserialize(reader);
			
			PivotA = new Vector4();
			PivotA.Deserialize(reader);
			
			AxleB = new Vector4();
			AxleB.Deserialize(reader);
			
			Perp2AxleInB1 = new Vector4();
			Perp2AxleInB1.Deserialize(reader);
			
			Perp2AxleInB2 = new Vector4();
			Perp2AxleInB2.Deserialize(reader);
			
			PivotB = new Vector4();
			PivotB.Deserialize(reader);
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(AxleA);
			
			writer.Write(Perp2AxleInA1);
			
			writer.Write(Perp2AxleInA2);
			
			writer.Write(PivotA);
			
			writer.Write(AxleB);
			
			writer.Write(Perp2AxleInB1);
			
			writer.Write(Perp2AxleInB2);
			
			writer.Write(PivotB);
			
		}
	}
	

}
