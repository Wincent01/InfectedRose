using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This is the most common collision object found in NIF files. It acts as a real object that
	///         is visible and possibly (if the body allows for it) interactive. The node itself
	///         is simple, it only has three properties.
	///         For this type of collision object, bhkRigidBody or bhkRigidBodyT is generally used.
	///         
	/// </summary>
	public class NiCollisionObject : NiObject
	{
		/// <summary>
		/// Index of the AV object referring to this collision object.
		/// </summary>
		public Ptr<NiAVObject> Target { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Target = reader.Read<Ptr<NiAVObject>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Target);
			
		}
	}
	

}
