using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiPSysMeshUpdateModifier : NiPSysModifier
	{
		/// <summary>
		/// The number of object references that follow.
		/// </summary>
		public uint NumMeshes { get; set; } 
		
		/// <summary>
		/// Group of target NiNodes or NiTriShapes?
		/// </summary>
		public Ptr<NiAVObject>[] Meshes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumMeshes = reader.Read<uint>();
			
			Meshes = new Ptr<NiAVObject>[NumMeshes];
			for (var i = 0; i < NumMeshes; i++)
			{
				Meshes[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumMeshes);
			
			for (var i = 0; i < NumMeshes; i++)
			{
				writer.Write(Meshes[i]);
			}
			
		}
	}
	

}
