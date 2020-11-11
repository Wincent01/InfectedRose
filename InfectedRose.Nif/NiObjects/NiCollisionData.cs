using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Collision box.
	///         
	/// </summary>
	public class NiCollisionData : NiCollisionObject
	{
		/// <summary>
		/// Propagation Mode
		/// </summary>
		public PropagationMode PropagationMode { get; set; } 
		
		/// <summary>
		/// Collision Mode
		/// </summary>
		public CollisionMode CollisionMode { get; set; } 
		
		/// <summary>
		/// Use Alternate Bounding Volume.
		/// </summary>
		public byte UseABV { get; set; } 
		
		/// <summary>
		/// Collision data.
		/// </summary>
		public BoundingVolume BoundingVolume { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			PropagationMode = (PropagationMode) reader.Read<uint>();
			
			CollisionMode = (CollisionMode) reader.Read<uint>();
			
			UseABV = reader.Read<byte>();
			
			if (UseABV==1)
			{
				BoundingVolume = new BoundingVolume();
				BoundingVolume.Deserialize(reader);
				
			}
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((uint) PropagationMode);
			
			writer.Write((uint) CollisionMode);
			
			writer.Write(UseABV);
			
			if (UseABV==1)
			{
				writer.Write(BoundingVolume);
				
			}
		}
	}
	

}
