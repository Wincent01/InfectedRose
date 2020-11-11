using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Voxel data object.
	///         
	/// </summary>
	public class NiBinaryVoxelData : NiObject
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Unknown. Is this^3 the Unknown Bytes 1 size?
		/// </summary>
		public ushort UnknownShort3 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float[] Unknown7Floats { get; set; } 
		
		/// <summary>
		/// Unknown. Always a multiple of 7.
		/// </summary>
		public byte[,] UnknownBytes1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint NumUnknownVectors { get; set; } 
		
		/// <summary>
		/// Vectors on the unit sphere.
		/// </summary>
		public Vector4[] UnknownVectors { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint NumUnknownBytes2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte[] UnknownBytes2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint[] Unknown5Ints { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort1 = reader.Read<ushort>();
			
			UnknownShort2 = reader.Read<ushort>();
			
			UnknownShort3 = reader.Read<ushort>();
			
			Unknown7Floats = new float[7];
			for (var i = 0; i < 7; i++)
			{
				Unknown7Floats[i] = reader.Read<float>();
			}
			
			UnknownBytes1 = new byte[7, 12];
			for (var i = 0; i < 7; i++)
			{
				for (var j = 0; j < 12; j++)
				{
					UnknownBytes1[i, j] = reader.Read<byte>();
				}
			}
			
			NumUnknownVectors = reader.Read<uint>();
			
			UnknownVectors = new Vector4[NumUnknownVectors];
			for (var i = 0; i < NumUnknownVectors; i++)
			{
				var value = new Vector4();
				value.Deserialize(reader);
				UnknownVectors[i] = value;
			}
			
			NumUnknownBytes2 = reader.Read<uint>();
			
			UnknownBytes2 = new byte[NumUnknownBytes2];
			for (var i = 0; i < NumUnknownBytes2; i++)
			{
				UnknownBytes2[i] = reader.Read<byte>();
			}
			
			Unknown5Ints = new uint[5];
			for (var i = 0; i < 5; i++)
			{
				Unknown5Ints[i] = reader.Read<uint>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort1);
			
			writer.Write(UnknownShort2);
			
			writer.Write(UnknownShort3);
			
			for (var i = 0; i < 7; i++)
			{
				writer.Write(Unknown7Floats[i]);
			}
			
			for (var i = 0; i < 7; i++)
			{
				for (var j = 0; j < 12; j++)
				{
					writer.Write(UnknownBytes1[i, j]);
				}
			}
			
			writer.Write(NumUnknownVectors);
			
			for (var i = 0; i < NumUnknownVectors; i++)
			{
				writer.Write(UnknownVectors[i]);
			}
			
			writer.Write(NumUnknownBytes2);
			
			for (var i = 0; i < NumUnknownBytes2; i++)
			{
				writer.Write(UnknownBytes2[i]);
			}
			
			for (var i = 0; i < 5; i++)
			{
				writer.Write(Unknown5Ints[i]);
			}
			
		}
	}
	

}
