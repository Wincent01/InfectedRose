using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class BoundingVolume : IConstruct
	{
		/// <summary>
		/// Type of collision data.
		/// </summary>
		public BoundVolumeType CollisionType { get; set; } 
		
		/// <summary>
		/// Sphere
		/// </summary>
		public SphereBV Sphere { get; set; } 
		
		/// <summary>
		/// Box
		/// </summary>
		public BoxBV Box { get; set; } 
		
		/// <summary>
		/// Capsule
		/// </summary>
		public CapsuleBV Capsule { get; set; } 
		
		/// <summary>
		/// Union
		/// </summary>
		public UnionBV Union { get; set; } 
		
		/// <summary>
		/// Half Space
		/// </summary>
		public HalfSpaceBV HalfSpace { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			CollisionType = (BoundVolumeType) reader.Read<uint>();
			
			if (CollisionType==0)
			{
				Sphere = new SphereBV();
				Sphere.Deserialize(reader);
				
			}
			if (CollisionType== (BoundVolumeType) 1)
			{
				Box = new BoxBV();
				Box.Deserialize(reader);
				
			}
			if (CollisionType== (BoundVolumeType) 2)
			{
				Capsule = new CapsuleBV();
				Capsule.Deserialize(reader);
				
			}
			if (CollisionType== (BoundVolumeType) 4)
			{
				Union = new UnionBV();
				Union.Deserialize(reader);
				
			}
			if (CollisionType== (BoundVolumeType) 5)
			{
				HalfSpace = new HalfSpaceBV();
				HalfSpace.Deserialize(reader);
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write((uint) CollisionType);
			
			if (CollisionType==0)
			{
				writer.Write(Sphere);
				
			}
			if (CollisionType== (BoundVolumeType) 1)
			{
				writer.Write(Box);
				
			}
			if (CollisionType== (BoundVolumeType) 2)
			{
				writer.Write(Capsule);
				
			}
			if (CollisionType== (BoundVolumeType) 4)
			{
				writer.Write(Union);
				
			}
			if (CollisionType== (BoundVolumeType) 5)
			{
				writer.Write(HalfSpace);
				
			}
		}
	}
	

}
