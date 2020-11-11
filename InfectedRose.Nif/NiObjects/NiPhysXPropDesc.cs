using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXPropDesc : NiObject
	{
		/// <summary>
		/// Number of NiPhysXActorDesc references
		/// </summary>
		public int NumDests { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiPhysXActorDesc>[] ActorDescs { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint NumJoints { get; set; } 
		
		/// <summary>
		/// PhysX Joint Descriptions
		/// </summary>
		public Ptr<NiPhysXD6JointDesc>[] JointDescs { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint NumMaterials { get; set; } 
		
		/// <summary>
		/// PhysX Material Descriptions
		/// </summary>
		public physXMaterialRef[] MaterialDescs { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumDests = reader.Read<int>();
			
			ActorDescs = new Ptr<NiPhysXActorDesc>[NumDests];
			for (var i = 0; i < NumDests; i++)
			{
				ActorDescs[i] = reader.Read<Ptr<NiPhysXActorDesc>>();
			}
			
			NumJoints = reader.Read<uint>();
			
			JointDescs = new Ptr<NiPhysXD6JointDesc>[NumJoints];
			for (var i = 0; i < NumJoints; i++)
			{
				JointDescs[i] = reader.Read<Ptr<NiPhysXD6JointDesc>>();
			}
			
			UnknownInt1 = reader.Read<int>();
			
			NumMaterials = reader.Read<uint>();
			
			MaterialDescs = new physXMaterialRef[NumMaterials];
			for (var i = 0; i < NumMaterials; i++)
			{
				var value = new physXMaterialRef();
				value.Deserialize(reader);
				MaterialDescs[i] = value;
			}
			
			UnknownInt2 = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumDests);
			
			for (var i = 0; i < NumDests; i++)
			{
				writer.Write(ActorDescs[i]);
			}
			
			writer.Write(NumJoints);
			
			for (var i = 0; i < NumJoints; i++)
			{
				writer.Write(JointDescs[i]);
			}
			
			writer.Write(UnknownInt1);
			
			writer.Write(NumMaterials);
			
			for (var i = 0; i < NumMaterials; i++)
			{
				writer.Write(MaterialDescs[i]);
			}
			
			writer.Write(UnknownInt2);
			
		}
	}
	

}
