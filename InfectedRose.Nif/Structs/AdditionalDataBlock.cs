using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public struct AdditionalDataBlock : IConstruct
	{
		/// <summary>
		/// Has data
		/// </summary>
		public bool HasData { get; set; } 
		
		/// <summary>
		/// Size of Block
		/// </summary>
		public int BlockSize { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int NumBlocks { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int[] BlockOffsets { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int NumData { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int[] DataSizes { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte[,] Data { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			HasData = reader.Read<byte>() != 0;
			
			if (HasData)
			{
				BlockSize = reader.Read<int>();
				
			}
			if (HasData)
			{
				NumBlocks = reader.Read<int>();
				
			}
			if (HasData)
			{
				BlockOffsets = new int[NumBlocks];
				for (var i = 0; i < NumBlocks; i++)
				{
					BlockOffsets[i] = reader.Read<int>();
				}
				
			}
			if (HasData)
			{
				NumData = reader.Read<int>();
				
			}
			if (HasData)
			{
				DataSizes = new int[NumData];
				for (var i = 0; i < NumData; i++)
				{
					DataSizes[i] = reader.Read<int>();
				}
				
			}
			if (HasData)
			{
				Data = new byte[NumData, BlockSize];
				for (var i = 0; i < NumData; i++)
				{
					for (var j = 0; j < BlockSize; j++)
					{
						Data[i, j] = reader.Read<byte>();
					}
				}
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write((byte) (HasData ? 1 : 0));
			
			if (HasData)
			{
				writer.Write(BlockSize);
				
			}
			if (HasData)
			{
				writer.Write(NumBlocks);
				
			}
			if (HasData)
			{
				for (var i = 0; i < NumBlocks; i++)
				{
					writer.Write(BlockOffsets[i]);
				}
				
			}
			if (HasData)
			{
				writer.Write(NumData);
				
			}
			if (HasData)
			{
				for (var i = 0; i < NumData; i++)
				{
					writer.Write(DataSizes[i]);
				}
				
			}
			if (HasData)
			{
				for (var i = 0; i < NumData; i++)
				{
					for (var j = 0; j < BlockSize; j++)
					{
						writer.Write(Data[i, j]);
					}
				}
				
			}
		}
	}
	

}
