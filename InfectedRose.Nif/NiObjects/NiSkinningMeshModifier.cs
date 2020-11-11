using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiSkinningMeshModifier : NiMeshModifier
	{
		/// <summary>
		/// 
		///             USE_SOFTWARE_SKINNING = 0x0001
		///             RECOMPUTE_BOUNDS = 0x0002
		///         
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// The root bone of the skeleton.
		/// </summary>
		public Ptr<NiAVObject> SkeletonRoot { get; set; } 
		
		/// <summary>
		/// The transform that takes the root bone parent coordinate system into the skin coordinate system.
		/// </summary>
		public SkinTransform SkeletonTransform { get; set; } 
		
		/// <summary>
		/// The number of bones referenced by this mesh modifier.
		/// </summary>
		public uint NumBones { get; set; } 
		
		/// <summary>
		/// Pointers to the bone nodes that affect this skin.
		/// </summary>
		public Ptr<NiAVObject>[] Bones { get; set; } 
		
		/// <summary>
		/// The transforms that go from bind-pose space to bone space.
		/// </summary>
		public SkinTransform[] BoneTransforms { get; set; } 
		
		/// <summary>
		/// The bounds of the bones.  Only stored if the RECOMPUTE_BOUNDS bit is set.
		/// </summary>
		public SphereBV[] BoneBounds { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			SkeletonRoot = reader.Read<Ptr<NiAVObject>>();
			
			SkeletonTransform = new SkinTransform();
			SkeletonTransform.Deserialize(reader);
			
			NumBones = reader.Read<uint>();
			
			Bones = new Ptr<NiAVObject>[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				Bones[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
			BoneTransforms = new SkinTransform[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				var value = new SkinTransform();
				value.Deserialize(reader);
				BoneTransforms[i] = value;
			}
			
			if ((Flags&2)!=0)
			{
				BoneBounds = new SphereBV[NumBones];
				for (var i = 0; i < NumBones; i++)
				{
					var value = new SphereBV();
					value.Deserialize(reader);
					BoneBounds[i] = value;
				}
				
			}
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(SkeletonRoot);
			
			writer.Write(SkeletonTransform);
			
			writer.Write(NumBones);
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(Bones[i]);
			}
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(BoneTransforms[i]);
			}
			
			if ((Flags&2)!=0)
			{
				for (var i = 0; i < NumBones; i++)
				{
					writer.Write(BoneBounds[i]);
				}
				
			}
		}
	}
	

}
