using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Skinning data, optimized for hardware skinning. The mesh is partitioned in submeshes such that each vertex of a submesh is influenced only by a limited and fixed number of bones.
	///         
	/// </summary>
	public class NiSkinPartition : NiObject
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint NumSkinPartitionBlocks { get; set; } 
		
		/// <summary>
		/// Skin partition objects.
		/// </summary>
		public SkinPartition[] SkinPartitionBlocks { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumSkinPartitionBlocks = reader.Read<uint>();
			
			SkinPartitionBlocks = new SkinPartition[NumSkinPartitionBlocks];
			for (var i = 0; i < NumSkinPartitionBlocks; i++)
			{
				var value = new SkinPartition();
				value.Deserialize(reader);
				SkinPartitionBlocks[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumSkinPartitionBlocks);
			
			for (var i = 0; i < NumSkinPartitionBlocks; i++)
			{
				writer.Write(SkinPartitionBlocks[i]);
			}
			
		}
	}
	

}
