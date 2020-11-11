using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiFurSpringController : NiTimeController
	{
		/// <summary>
		/// 
		/// </summary>
		public float UnknownFloat { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// The number of node bones referenced as influences.
		/// </summary>
		public uint NumBones { get; set; } 
		
		/// <summary>
		/// List of all armature bones.
		/// </summary>
		public Ptr<NiNode>[] Bones { get; set; } 
		
		/// <summary>
		/// The number of node bones referenced as influences.
		/// </summary>
		public uint NumBones2 { get; set; } 
		
		/// <summary>
		/// List of all armature bones.
		/// </summary>
		public Ptr<NiNode>[] Bones2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFloat = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			NumBones = reader.Read<uint>();
			
			Bones = new Ptr<NiNode>[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				Bones[i] = reader.Read<Ptr<NiNode>>();
			}
			
			NumBones2 = reader.Read<uint>();
			
			Bones2 = new Ptr<NiNode>[NumBones2];
			for (var i = 0; i < NumBones2; i++)
			{
				Bones2[i] = reader.Read<Ptr<NiNode>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownFloat);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(NumBones);
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(Bones[i]);
			}
			
			writer.Write(NumBones2);
			
			for (var i = 0; i < NumBones2; i++)
			{
				writer.Write(Bones2[i]);
			}
			
		}
	}
	

}
