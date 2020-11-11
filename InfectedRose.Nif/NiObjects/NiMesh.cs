using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiMesh : NiRenderObject
	{
		/// <summary>
		/// The primitive type of the mesh, such as triangles or lines.
		/// </summary>
		public MeshPrimitiveType PrimitiveType { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown51 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown52 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown53 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown54 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown55 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown56 { get; set; } 
		
		/// <summary>
		/// The number of submeshes contained in this mesh.
		/// </summary>
		public ushort NumSubmeshes { get; set; } 
		
		/// <summary>
		/// Sets whether hardware instancing is being used.
		/// </summary>
		public bool InstancingEnabled { get; set; } 
		
		/// <summary>
		/// The combined bounding volume of all submeshes.
		/// </summary>
		public SphereBV Bound { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public uint NumDatas { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public MeshData[] Datas { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public uint NumModifiers { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiMeshModifier>[] Modifiers { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte Unknown100 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public int Unknown101 { get; set; } 
		
		/// <summary>
		/// Size of additional data.
		/// </summary>
		public uint Unknown102 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float[] Unknown103 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown200 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ExtraMeshDataEpicMickey[] Unknown201 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown250 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int[] Unknown251 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown300 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public short Unknown301 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown302 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte[] Unknown303 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown350 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ExtraMeshDataEpicMickey2[] Unknown351 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown400 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			PrimitiveType = (MeshPrimitiveType) reader.Read<uint>();
			
			Unknown51 = reader.Read<int>();
			
			Unknown52 = reader.Read<int>();
			
			Unknown53 = reader.Read<int>();
			
			Unknown54 = reader.Read<int>();
			
			Unknown55 = reader.Read<float>();
			
			Unknown56 = reader.Read<int>();
			
			NumSubmeshes = reader.Read<ushort>();
			
			InstancingEnabled = reader.Read<byte>() != 0;
			
			Bound = new SphereBV();
			Bound.Deserialize(reader);
			
			NumDatas = reader.Read<uint>();
			
			Datas = new MeshData[NumDatas];
			for (var i = 0; i < NumDatas; i++)
			{
				var value = new MeshData();
				value.Deserialize(reader);
				Datas[i] = value;
			}
			
			NumModifiers = reader.Read<uint>();
			
			Modifiers = new Ptr<NiMeshModifier>[NumModifiers];
			for (var i = 0; i < NumModifiers; i++)
			{
				Modifiers[i] = reader.Read<Ptr<NiMeshModifier>>();
			}
			
			Unknown100 = reader.Read<byte>();
			
			Unknown101 = reader.Read<int>();
			
			Unknown102 = reader.Read<uint>();
			
			Unknown103 = new float[Unknown102];
			for (var i = 0; i < Unknown102; i++)
			{
				Unknown103[i] = reader.Read<float>();
			}
			
			Unknown200 = reader.Read<int>();
			
			Unknown201 = new ExtraMeshDataEpicMickey[Unknown200];
			for (var i = 0; i < Unknown200; i++)
			{
				var value = new ExtraMeshDataEpicMickey();
				value.Deserialize(reader);
				Unknown201[i] = value;
			}
			
			Unknown250 = reader.Read<int>();
			
			Unknown251 = new int[Unknown250];
			for (var i = 0; i < Unknown250; i++)
			{
				Unknown251[i] = reader.Read<int>();
			}
			
			Unknown300 = reader.Read<int>();
			
			Unknown301 = reader.Read<short>();
			
			Unknown302 = reader.Read<int>();
			
			Unknown303 = new byte[Unknown302];
			for (var i = 0; i < Unknown302; i++)
			{
				Unknown303[i] = reader.Read<byte>();
			}
			
			Unknown350 = reader.Read<int>();
			
			Unknown351 = new ExtraMeshDataEpicMickey2[Unknown350];
			for (var i = 0; i < Unknown350; i++)
			{
				var value = new ExtraMeshDataEpicMickey2();
				value.Deserialize(reader);
				Unknown351[i] = value;
			}
			
			Unknown400 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((uint) PrimitiveType);
			
			writer.Write(Unknown51);
			
			writer.Write(Unknown52);
			
			writer.Write(Unknown53);
			
			writer.Write(Unknown54);
			
			writer.Write(Unknown55);
			
			writer.Write(Unknown56);
			
			writer.Write(NumSubmeshes);
			
			writer.Write((byte) (InstancingEnabled ? 1 : 0));
			
			writer.Write(Bound);
			
			writer.Write(NumDatas);
			
			for (var i = 0; i < NumDatas; i++)
			{
				writer.Write(Datas[i]);
			}
			
			writer.Write(NumModifiers);
			
			for (var i = 0; i < NumModifiers; i++)
			{
				writer.Write(Modifiers[i]);
			}
			
			writer.Write(Unknown100);
			
			writer.Write(Unknown101);
			
			writer.Write(Unknown102);
			
			for (var i = 0; i < Unknown102; i++)
			{
				writer.Write(Unknown103[i]);
			}
			
			writer.Write(Unknown200);
			
			for (var i = 0; i < Unknown200; i++)
			{
				writer.Write(Unknown201[i]);
			}
			
			writer.Write(Unknown250);
			
			for (var i = 0; i < Unknown250; i++)
			{
				writer.Write(Unknown251[i]);
			}
			
			writer.Write(Unknown300);
			
			writer.Write(Unknown301);
			
			writer.Write(Unknown302);
			
			for (var i = 0; i < Unknown302; i++)
			{
				writer.Write(Unknown303[i]);
			}
			
			writer.Write(Unknown350);
			
			for (var i = 0; i < Unknown350; i++)
			{
				writer.Write(Unknown351[i]);
			}
			
			writer.Write(Unknown400);
			
		}
	}
	

}
