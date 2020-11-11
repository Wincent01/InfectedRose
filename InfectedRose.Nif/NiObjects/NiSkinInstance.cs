using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Skinning instance.
	///         
	/// </summary>
	public class NiSkinInstance : NiObject
	{
		/// <summary>
		/// Skinning data reference.
		/// </summary>
		public Ptr<NiSkinData> Data { get; set; } 
		
		/// <summary>
		/// Refers to a NiSkinPartition objects, which partitions the mesh such that every vertex is only influenced by a limited number of bones.
		/// </summary>
		public Ptr<NiSkinPartition> SkinPartition { get; set; } 
		
		/// <summary>
		/// Armature root node.
		/// </summary>
		public Ptr<NiNode> SkeletonRoot { get; set; } 
		
		/// <summary>
		/// The number of node bones referenced as influences.
		/// </summary>
		public uint NumBones { get; set; } 
		
		/// <summary>
		/// List of all armature bones.
		/// </summary>
		public Ptr<NiNode>[] Bones { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = reader.Read<Ptr<NiSkinData>>();
			
			SkinPartition = reader.Read<Ptr<NiSkinPartition>>();
			
			SkeletonRoot = reader.Read<Ptr<NiNode>>();
			
			NumBones = reader.Read<uint>();
			
			Bones = new Ptr<NiNode>[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				Bones[i] = reader.Read<Ptr<NiNode>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
			writer.Write(SkinPartition);
			
			writer.Write(SkeletonRoot);
			
			writer.Write(NumBones);
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(Bones[i]);
			}
			
		}
	}
	

}
