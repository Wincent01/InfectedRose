using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Adds gravity to a particle system, when linked to a NiNode to use as a Gravity Object.
	///         
	/// </summary>
	public class NiPSysGravityModifier : NiPSysModifier
	{
		/// <summary>
		/// Refers to a NiNode for gravity location.
		/// </summary>
		public Ptr<NiNode> GravityObject { get; set; } 
		
		/// <summary>
		/// Orientation of gravity.
		/// </summary>
		public Vector3 GravityAxis { get; set; } 
		
		/// <summary>
		/// Falloff range.
		/// </summary>
		public float Decay { get; set; } 
		
		/// <summary>
		/// The strength of gravity.
		/// </summary>
		public float Strength { get; set; } 
		
		/// <summary>
		/// Planar or Spherical type
		/// </summary>
		public ForceType ForceType { get; set; } 
		
		/// <summary>
		/// Adds a degree of randomness.
		/// </summary>
		public float Turbulence { get; set; } 
		
		/// <summary>
		/// Range for turbulence.
		/// </summary>
		public float TurbulenceScale { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			GravityObject = reader.Read<Ptr<NiNode>>();
			
			GravityAxis = new Vector3();
			GravityAxis.Deserialize(reader);
			
			Decay = reader.Read<float>();
			
			Strength = reader.Read<float>();
			
			ForceType = (ForceType) reader.Read<uint>();
			
			Turbulence = reader.Read<float>();
			
			TurbulenceScale = reader.Read<float>();
			
			UnknownByte = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(GravityObject);
			
			writer.Write(GravityAxis);
			
			writer.Write(Decay);
			
			writer.Write(Strength);
			
			writer.Write((uint) ForceType);
			
			writer.Write(Turbulence);
			
			writer.Write(TurbulenceScale);
			
			writer.Write(UnknownByte);
			
		}
	}
	

}
