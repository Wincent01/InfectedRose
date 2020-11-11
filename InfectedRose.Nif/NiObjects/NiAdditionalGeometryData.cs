using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiAdditionalGeometryData : AbstractAdditionalGeometryData
	{
		/// <summary>
		/// Number of vertices
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// Information about additional data blocks
		/// </summary>
		public uint NumBlockInfos { get; set; } 
		
		/// <summary>
		/// Number of additional data blocks
		/// </summary>
		public AdditionalDataInfo[] BlockInfos { get; set; } 
		
		/// <summary>
		/// Number of additional data blocks
		/// </summary>
		public int NumBlocks { get; set; } 
		
		/// <summary>
		/// Number of additional data blocks
		/// </summary>
		public AdditionalDataBlock[] Blocks { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumVertices = reader.Read<ushort>();
			
			NumBlockInfos = reader.Read<uint>();
			
			BlockInfos = new AdditionalDataInfo[NumBlockInfos];
			for (var i = 0; i < NumBlockInfos; i++)
			{
				var value = new AdditionalDataInfo();
				value.Deserialize(reader);
				BlockInfos[i] = value;
			}
			
			NumBlocks = reader.Read<int>();
			
			Blocks = new AdditionalDataBlock[NumBlocks];
			for (var i = 0; i < NumBlocks; i++)
			{
				var value = new AdditionalDataBlock();
				value.Deserialize(reader);
				Blocks[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumVertices);
			
			writer.Write(NumBlockInfos);
			
			for (var i = 0; i < NumBlockInfos; i++)
			{
				writer.Write(BlockInfos[i]);
			}
			
			writer.Write(NumBlocks);
			
			for (var i = 0; i < NumBlocks; i++)
			{
				writer.Write(Blocks[i]);
			}
			
		}
	}
	

}
