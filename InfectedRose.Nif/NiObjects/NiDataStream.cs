using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiDataStream : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public DataStreamUsage Usage { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public uint Access { get; set; } 
		
		/// <summary>
		/// The size in bytes of this data stream.
		/// </summary>
		public uint NumBytes { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public CloningBehavior CloningBehavior { get; set; } 
		
		/// <summary>
		/// Number of regions (such as submeshes).
		/// </summary>
		public uint NumRegions { get; set; } 
		
		/// <summary>
		/// The regions in the mesh. Regions can be used to mark off submeshes which are independent draw calls.
		/// </summary>
		public Region[] Regions { get; set; } 
		
		/// <summary>
		/// Number of components of the data (matches corresponding field in MeshData).
		/// </summary>
		public uint NumComponents { get; set; } 
		
		/// <summary>
		/// The format of each component in this data stream.
		/// </summary>
		public ComponentFormat[] ComponentFormats { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte[] Data { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public bool Streamable { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Usage = (DataStreamUsage) reader.Read<uint>();

			Access = reader.Read<uint>();
			
			NumBytes = reader.Read<uint>();
			
			CloningBehavior = (CloningBehavior) reader.Read<uint>();
			
			NumRegions = reader.Read<uint>();
			
			Regions = new Region[NumRegions];
			for (var i = 0; i < NumRegions; i++)
			{
				var value = new Region();
				value.Deserialize(reader);
				Regions[i] = value;
			}
			
			NumComponents = reader.Read<uint>();
			
			ComponentFormats = new ComponentFormat[NumComponents];
			for (var i = 0; i < NumComponents; i++)
			{
				ComponentFormats[i] = (ComponentFormat) reader.Read<uint>();
			}
			
			Data = new byte[NumBytes];
			for (var i = 0; i < NumBytes; i++)
			{
				Data[i] = reader.Read<byte>();
			}
			
			Streamable = reader.Read<byte>() != 0;
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((uint) Usage);
			
			writer.Write(Access);
			
			writer.Write(NumBytes);
			
			writer.Write((uint) CloningBehavior);
			
			writer.Write(NumRegions);
			
			for (var i = 0; i < NumRegions; i++)
			{
				writer.Write(Regions[i]);
			}
			
			writer.Write(NumComponents);
			
			for (var i = 0; i < NumComponents; i++)
			{
				writer.Write((uint) ComponentFormats[i]);
			}
			
			for (var i = 0; i < NumBytes; i++)
			{
				writer.Write(Data[i]);
			}
			
			writer.Write((byte) (Streamable ? 1 : 0));
			
		}
	}
	

}
