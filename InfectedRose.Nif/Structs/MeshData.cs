using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct MeshData : IConstruct
	{
		/// <summary>
		/// 
		///             Reference to a data stream object which holds the data used by
		///             this reference.
		///         
		/// </summary>
		public Ptr<NiDataStream> Stream { get; set; } 
		
		/// <summary>
		/// 
		///             Sets whether this stream data is per-instance data for use in
		///             hardware instancing.
		///         
		/// </summary>
		public bool IsPerInstance { get; set; } 
		
		/// <summary>
		/// 
		///             The number of submesh-to-region mappings that this data stream
		///             has.
		///         
		/// </summary>
		public ushort NumSubmeshes { get; set; } 
		
		/// <summary>
		/// 
		///             A lookup table that maps submeshes to regions.
		///         
		/// </summary>
		public ushort[] SubmeshToRegionMap { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int NumComponents { get; set; } 
		
		/// <summary>
		/// Describes the semantic of each component.
		/// </summary>
		public SemanticData[] ComponentSemantics { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Stream = reader.Read<Ptr<NiDataStream>>();
			
			IsPerInstance = reader.Read<byte>() != 0;
			
			NumSubmeshes = reader.Read<ushort>();
			
			SubmeshToRegionMap = new ushort[NumSubmeshes];
			for (var i = 0; i < NumSubmeshes; i++)
			{
				SubmeshToRegionMap[i] = reader.Read<ushort>();
			}
			
			NumComponents = reader.Read<int>();
			
			ComponentSemantics = new SemanticData[NumComponents];
			for (var i = 0; i < NumComponents; i++)
			{
				var value = new SemanticData();
				value.Deserialize(reader);
				ComponentSemantics[i] = value;
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Stream);
			
			writer.Write((byte) (IsPerInstance ? 1 : 0));
			
			writer.Write(NumSubmeshes);
			
			for (var i = 0; i < NumSubmeshes; i++)
			{
				writer.Write(SubmeshToRegionMap[i]);
			}
			
			writer.Write(NumComponents);
			
			for (var i = 0; i < NumComponents; i++)
			{
				writer.Write(ComponentSemantics[i]);
			}
			
		}
	}
	

}
