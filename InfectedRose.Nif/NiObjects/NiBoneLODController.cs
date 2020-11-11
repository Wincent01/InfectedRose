using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Level of detail controller for bones.  Priority is arranged from low to high.
	///         
	/// </summary>
	public class NiBoneLODController : NiTimeController
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Number of node groups.
		/// </summary>
		public uint NumNodeGroups { get; set; } 
		
		/// <summary>
		/// Number of node groups.
		/// </summary>
		public uint NumNodeGroups2 { get; set; } 
		
		/// <summary>
		/// A list of node groups (each group a sequence of bones).
		/// </summary>
		public NodeGroup[] NodeGroups { get; set; } 
		
		/// <summary>
		/// Number of shape groups.
		/// </summary>
		public uint NumShapeGroups { get; set; } 
		
		/// <summary>
		/// List of shape groups.
		/// </summary>
		public SkinShapeGroup[] ShapeGroups1 { get; set; } 
		
		/// <summary>
		/// The size of the second list of shape groups.
		/// </summary>
		public uint NumShapeGroups2 { get; set; } 
		
		/// <summary>
		/// Group of NiTriShape indices.
		/// </summary>
		public Ptr<NiTriBasedGeom>[] ShapeGroups2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public int UnknownInt3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt1 = reader.Read<uint>();
			
			NumNodeGroups = reader.Read<uint>();
			
			NumNodeGroups2 = reader.Read<uint>();
			
			NodeGroups = new NodeGroup[NumNodeGroups];
			for (var i = 0; i < NumNodeGroups; i++)
			{
				var value = new NodeGroup();
				value.Deserialize(reader);
				NodeGroups[i] = value;
			}
			
			NumShapeGroups = reader.Read<uint>();
			
			ShapeGroups1 = new SkinShapeGroup[NumShapeGroups];
			for (var i = 0; i < NumShapeGroups; i++)
			{
				var value = new SkinShapeGroup();
				value.Deserialize(reader);
				ShapeGroups1[i] = value;
			}
			
			NumShapeGroups2 = reader.Read<uint>();
			
			ShapeGroups2 = new Ptr<NiTriBasedGeom>[NumShapeGroups2];
			for (var i = 0; i < NumShapeGroups2; i++)
			{
				ShapeGroups2[i] = reader.Read<Ptr<NiTriBasedGeom>>();
			}
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownInt3 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt1);
			
			writer.Write(NumNodeGroups);
			
			writer.Write(NumNodeGroups2);
			
			for (var i = 0; i < NumNodeGroups; i++)
			{
				writer.Write(NodeGroups[i]);
			}
			
			writer.Write(NumShapeGroups);
			
			for (var i = 0; i < NumShapeGroups; i++)
			{
				writer.Write(ShapeGroups1[i]);
			}
			
			writer.Write(NumShapeGroups2);
			
			for (var i = 0; i < NumShapeGroups2; i++)
			{
				writer.Write(ShapeGroups2[i]);
			}
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownInt3);
			
		}
	}
	

}
