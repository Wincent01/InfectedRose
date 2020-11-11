using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Generic node object.
	///         
	/// </summary>
	public abstract class NiAVObject : NiObjectNET
	{
		/// <summary>
		/// Some flags; commonly 0x000C or 0x000A.
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Unknown Flag
		/// </summary>
		public ushort UnknownShort1 { get; set; } 
		
		/// <summary>
		/// The translation vector.
		/// </summary>
		public Vector3 Translation { get; set; } 
		
		/// <summary>
		/// The rotation part of the transformation matrix.
		/// </summary>
		public Matrix33 Rotation { get; set; } 
		
		/// <summary>
		/// Scaling part (only uniform scaling is supported).
		/// </summary>
		public float Scale { get; set; } 
		
		/// <summary>
		/// The number of property objects referenced.
		/// </summary>
		public uint NumProperties { get; set; } 
		
		/// <summary>
		/// List of node properties.
		/// </summary>
		public Ptr<NiProperty>[] Properties { get; set; } 
		
		/// <summary>
		/// Refers to NiCollisionObject, which is usually a bounding box or other simple collision shape.  In Oblivion this links the Havok objects.
		/// </summary>
		public Ptr<NiCollisionObject> CollisionObject { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			//UnknownShort1 = reader.Read<ushort>();
			
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Rotation = new Matrix33();
			Rotation.Deserialize(reader);
			
			Scale = reader.Read<float>();
			
			NumProperties = reader.Read<uint>();
			
			Properties = new Ptr<NiProperty>[NumProperties];
			for (var i = 0; i < NumProperties; i++)
			{
				Properties[i] = reader.Read<Ptr<NiProperty>>();
			}
			
			CollisionObject = reader.Read<Ptr<NiCollisionObject>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			//writer.Write(UnknownShort1);
			
			writer.Write(Translation);
			
			writer.Write(Rotation);
			
			writer.Write(Scale);
			
			writer.Write(NumProperties);
			
			for (var i = 0; i < NumProperties; i++)
			{
				writer.Write(Properties[i]);
			}
			
			writer.Write(CollisionObject);
			
		}
	}
	

}
