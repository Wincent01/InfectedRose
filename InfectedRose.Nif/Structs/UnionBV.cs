using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class UnionBV : IConstruct
	{
		/// <summary>
		/// Number of Bounding Volumes.
		/// </summary>
		public uint NumBV { get; set; } 
		
		/// <summary>
		/// Bounding Volume.
		/// </summary>
		public BoundingVolume[] BoundingVolumes { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumBV = reader.Read<uint>();
			
			BoundingVolumes = new BoundingVolume[NumBV];
			for (var i = 0; i < NumBV; i++)
			{
				var value = new BoundingVolume();
				value.Deserialize(reader);
				BoundingVolumes[i] = value;
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumBV);
			
			for (var i = 0; i < NumBV; i++)
			{
				writer.Write(BoundingVolumes[i]);
			}
			
		}
	}
	

}
