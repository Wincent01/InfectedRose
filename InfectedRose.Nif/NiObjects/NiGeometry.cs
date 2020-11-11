using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes a visible scene element with vertices like a mesh, a particle system, lines, etc.
	///         
	/// </summary>
	public abstract class NiGeometry : NiAVObject
	{
		/// <summary>
		/// Data index (NiTriShapeData/NiTriStripData).
		/// </summary>
		public Ptr<NiGeometryData> Data { get; set; } 
		
		/// <summary>
		/// Skin instance index.
		/// </summary>
		public Ptr<NiSkinInstance> SkinInstance { get; set; } 
		
		/// <summary>
		/// Num Materials
		/// </summary>
		public uint NumMaterials { get; set; } 
		
		/// <summary>
		/// Unknown string.  Shader?
		/// </summary>
		public NiString[] MaterialName { get; set; } 
		
		/// <summary>
		/// Unknown integer; often -1. (Is this a link, array index?)
		/// </summary>
		public int[] MaterialExtraData { get; set; } 
		
		/// <summary>
		/// Active Material; often -1. (Is this a link, array index?)
		/// </summary>
		public int ActiveMaterial { get; set; } 
		
		/// <summary>
		/// Cyanide extension (only in version 10.2.0.0?).
		/// </summary>
		public byte UnknownByte { get; set; } 
		
		/// <summary>
		/// Dirty Flag?
		/// </summary>
		public bool DirtyFlag { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = reader.Read<Ptr<NiGeometryData>>();
			
			SkinInstance = reader.Read<Ptr<NiSkinInstance>>();
			
			NumMaterials = reader.Read<uint>();
			
			MaterialName = new NiString[NumMaterials];
			for (var i = 0; i < NumMaterials; i++)
			{
				var value = new NiString();
				value.Deserialize(reader);
				MaterialName[i] = value;
			}
			
			MaterialExtraData = new int[NumMaterials];
			for (var i = 0; i < NumMaterials; i++)
			{
				MaterialExtraData[i] = reader.Read<int>();
			}
			
			ActiveMaterial = reader.Read<int>();
			
			UnknownByte = reader.Read<byte>();
			
			DirtyFlag = reader.Read<byte>() != 0;
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
			writer.Write(SkinInstance);
			
			writer.Write(NumMaterials);
			
			for (var i = 0; i < NumMaterials; i++)
			{
				writer.Write(MaterialName[i]);
			}
			
			for (var i = 0; i < NumMaterials; i++)
			{
				writer.Write(MaterialExtraData[i]);
			}
			
			writer.Write(ActiveMaterial);
			
			writer.Write(UnknownByte);
			
			writer.Write((byte) (DirtyFlag ? 1 : 0));
			
		}
	}
	

}
