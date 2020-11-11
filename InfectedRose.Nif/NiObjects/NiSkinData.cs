using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Skinning data.
	///         
	/// </summary>
	public class NiSkinData : NiObject
	{
		/// <summary>
		/// Offset of the skin from this bone in bind position.
		/// </summary>
		public SkinTransform SkinTransform { get; set; } 
		
		/// <summary>
		/// Number of bones.
		/// </summary>
		public uint NumBones { get; set; } 
		
		/// <summary>
		/// Enables Vertex Weights for this NiSkinData.
		/// </summary>
		public byte HasVertexWeights { get; set; } 
		
		/// <summary>
		/// Contains offset data for each node that this skin is influenced by.
		/// </summary>
		public SkinData[] BoneList { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			SkinTransform = new SkinTransform();
			SkinTransform.Deserialize(reader);
			
			NumBones = reader.Read<uint>();
			
			HasVertexWeights = reader.Read<byte>();
			
			BoneList = new SkinData[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				var value = new SkinData();
				value.Deserialize(reader);
				BoneList[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(SkinTransform);
			
			writer.Write(NumBones);
			
			writer.Write(HasVertexWeights);
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(BoneList[i]);
			}
			
		}
	}
	

}
