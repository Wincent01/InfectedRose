using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle Collider object which particles will interact with.
	///         
	/// </summary>
	public class NiPSysPlanarCollider : NiPSysCollider
	{
		/// <summary>
		/// Defines the width of the plane.
		/// </summary>
		public float Width { get; set; } 
		
		/// <summary>
		/// Defines the height of the plane.
		/// </summary>
		public float Height { get; set; } 
		
		/// <summary>
		/// Defines Orientation.
		/// </summary>
		public Vector3 XAxis { get; set; } 
		
		/// <summary>
		/// Defines Orientation.
		/// </summary>
		public Vector3 YAxis { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Width = reader.Read<float>();
			
			Height = reader.Read<float>();
			
			XAxis = new Vector3();
			XAxis.Deserialize(reader);
			
			YAxis = new Vector3();
			YAxis.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Width);
			
			writer.Write(Height);
			
			writer.Write(XAxis);
			
			writer.Write(YAxis);
			
		}
	}
	

}
