using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes levels of detail based on distance of object from camera.
	///         
	/// </summary>
	public class NiRangeLODData : NiLODData
	{
		/// <summary>
		/// ?
		/// </summary>
		public Vector3 LODCenter { get; set; } 
		
		/// <summary>
		/// Number of levels of detail.
		/// </summary>
		public uint NumLODLevels { get; set; } 
		
		/// <summary>
		/// The ranges of distance that each level of detail applies in.
		/// </summary>
		public LODRange[] LODLevels { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			LODCenter = new Vector3();
			LODCenter.Deserialize(reader);
			
			NumLODLevels = reader.Read<uint>();
			
			LODLevels = new LODRange[NumLODLevels];
			for (var i = 0; i < NumLODLevels; i++)
			{
				var value = new LODRange();
				value.Deserialize(reader);
				LODLevels[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(LODCenter);
			
			writer.Write(NumLODLevels);
			
			for (var i = 0; i < NumLODLevels; i++)
			{
				writer.Write(LODLevels[i]);
			}
			
		}
	}
	

}
