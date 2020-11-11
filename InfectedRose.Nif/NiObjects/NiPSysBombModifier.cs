using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle modifier that uses a NiNode to use as a "Bomb Object" to alter the path of particles.
	///         
	/// </summary>
	public class NiPSysBombModifier : NiPSysModifier
	{
		/// <summary>
		/// Link to a NiNode for bomb to function.
		/// </summary>
		public Ptr<NiNode> BombObject { get; set; } 
		
		/// <summary>
		/// Orientation of bomb object.
		/// </summary>
		public Vector3 BombAxis { get; set; } 
		
		/// <summary>
		/// Falloff rate of the bomb object.
		/// </summary>
		public float Decay { get; set; } 
		
		/// <summary>
		/// DeltaV /  Strength?
		/// </summary>
		public float DeltaV { get; set; } 
		
		/// <summary>
		/// Decay type
		/// </summary>
		public DecayType DecayType { get; set; } 
		
		/// <summary>
		/// Shape/symmetry of the bomb object.
		/// </summary>
		public SymmetryType SymmetryType { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BombObject = reader.Read<Ptr<NiNode>>();
			
			BombAxis = new Vector3();
			BombAxis.Deserialize(reader);
			
			Decay = reader.Read<float>();
			
			DeltaV = reader.Read<float>();
			
			DecayType = (DecayType) reader.Read<uint>();
			
			SymmetryType = (SymmetryType) reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(BombObject);
			
			writer.Write(BombAxis);
			
			writer.Write(Decay);
			
			writer.Write(DeltaV);
			
			writer.Write((uint) DecayType);
			
			writer.Write((uint) SymmetryType);
			
		}
	}
	

}
