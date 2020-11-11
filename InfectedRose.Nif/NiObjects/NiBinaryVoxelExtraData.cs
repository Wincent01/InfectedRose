using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Voxel extra data object.
	///         
	/// </summary>
	public class NiBinaryVoxelExtraData : NiExtraData
	{
		/// <summary>
		/// Unknown.  0?
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Link to binary voxel data.
		/// </summary>
		public Ptr<NiBinaryVoxelData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt = reader.Read<uint>();
			
			Data = reader.Read<Ptr<NiBinaryVoxelData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt);
			
			writer.Write(Data);
			
		}
	}
	

}
