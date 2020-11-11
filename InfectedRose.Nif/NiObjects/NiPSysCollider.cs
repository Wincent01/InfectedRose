using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system collider.
	///         
	/// </summary>
	public abstract class NiPSysCollider : NiObject
	{
		/// <summary>
		/// Defines amount of bounce the collider object has.
		/// </summary>
		public float Bounce { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public bool SpawnonCollide { get; set; } 
		
		/// <summary>
		/// Kill particles on impact if set to yes.
		/// </summary>
		public bool DieonCollide { get; set; } 
		
		/// <summary>
		/// Link to NiPSysSpawnModifier object?
		/// </summary>
		public Ptr<NiPSysSpawnModifier> SpawnModifier { get; set; } 
		
		/// <summary>
		/// Link to parent.
		/// </summary>
		public Ptr<NiObject> Parent { get; set; } 
		
		/// <summary>
		/// The next collider.
		/// </summary>
		public Ptr<NiObject> NextCollider { get; set; } 
		
		/// <summary>
		/// Links to a NiNode that will define where in object space the collider is located/oriented.
		/// </summary>
		public Ptr<NiNode> ColliderObject { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Bounce = reader.Read<float>();
			
			SpawnonCollide = reader.Read<byte>() != 0;
			
			DieonCollide = reader.Read<byte>() != 0;
			
			SpawnModifier = reader.Read<Ptr<NiPSysSpawnModifier>>();
			
			Parent = reader.Read<Ptr<NiObject>>();
			
			NextCollider = reader.Read<Ptr<NiObject>>();
			
			ColliderObject = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Bounce);
			
			writer.Write((byte) (SpawnonCollide ? 1 : 0));
			
			writer.Write((byte) (DieonCollide ? 1 : 0));
			
			writer.Write(SpawnModifier);
			
			writer.Write(Parent);
			
			writer.Write(NextCollider);
			
			writer.Write(ColliderObject);
			
		}
	}
	

}
