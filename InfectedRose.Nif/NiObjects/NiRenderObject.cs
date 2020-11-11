using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An object that can be rendered.
	///         
	/// </summary>
	public class NiRenderObject : NiAVObject
	{
		/// <summary>
		/// The number of materials affecting this renderable object.
		/// </summary>
		public uint NumMaterials { get; set; } 
		
		/// <summary>
		/// Per-material data.
		/// </summary>
		public MaterialData[] MaterialData { get; set; } 
		
		/// <summary>
		/// The index of the currently active material.
		/// </summary>
		public int ActiveMaterial { get; set; } 
		
		/// <summary>
		/// The initial value for the flag that determines if the internal cached shader is valid.
		/// </summary>
		public bool MaterialNeedsUpdateDefault { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumMaterials = reader.Read<uint>();
			
			MaterialData = new MaterialData[NumMaterials];
			for (var i = 0; i < NumMaterials; i++)
			{
				var value = new MaterialData();
				value.Deserialize(reader);
				MaterialData[i] = value;
			}
			
			ActiveMaterial = reader.Read<int>();
			
			MaterialNeedsUpdateDefault = reader.Read<byte>() != 0;
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumMaterials);
			
			for (var i = 0; i < NumMaterials; i++)
			{
				writer.Write(MaterialData[i]);
			}
			
			writer.Write(ActiveMaterial);
			
			writer.Write((byte) (MaterialNeedsUpdateDefault ? 1 : 0));
			
		}
	}
	

}
