using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Old version of skinning instance.
	///         
	/// </summary>
	public class NiTriShapeSkinController : NiTimeController
	{
		/// <summary>
		/// The number of node bones referenced as influences.
		/// </summary>
		public uint NumBones { get; set; } 
		
		/// <summary>
		/// The number of vertex weights stored for each bone.
		/// </summary>
		public uint[] VertexCounts { get; set; } 
		
		/// <summary>
		/// List of all armature bones.
		/// </summary>
		public Ptr<NiBone>[] Bones { get; set; } 
		
		/// <summary>
		/// Contains skin weight data for each node that this skin is influenced by.
		/// </summary>
		public OldSkinData[][] BoneData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumBones = reader.Read<uint>();
			
			VertexCounts = new uint[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				VertexCounts[i] = reader.Read<uint>();
			}
			
			Bones = new Ptr<NiBone>[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				Bones[i] = reader.Read<Ptr<NiBone>>();
			}
			
			BoneData = new OldSkinData[NumBones][];
			for (var i = 0; i < NumBones; i++)
			{
				var length = VertexCounts[i];
				BoneData[i] = new OldSkinData[length];
				for (var j = 0; j < length; j++)
				{
					var value = new OldSkinData();
					value.Deserialize(reader);
					BoneData[i][j] = value;
				}
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumBones);
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(VertexCounts[i]);
			}
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(Bones[i]);
			}

			for (var i = 0; i < NumBones; i++)
			{
				var length = VertexCounts[i];

				for (var j = 0; j < length; j++)
				{
					writer.Write(BoneData[i][j]);
				}
			}
			
		}
	}
	

}
