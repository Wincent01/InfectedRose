using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown
	///         
	/// </summary>
	public class NiEnvMappedTriShape : NiObjectNET
	{
		/// <summary>
		/// unknown (=4 - 5)
		/// </summary>
		public ushort Unknown1 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Matrix44 UnknownMatrix { get; set; } 
		
		/// <summary>
		/// The number of child objects.
		/// </summary>
		public uint NumChildren { get; set; } 
		
		/// <summary>
		/// List of child node object indices.
		/// </summary>
		public Ptr<NiAVObject>[] Children { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Ptr<NiObject> Child2 { get; set; } 
		
		/// <summary>
		/// unknown
		/// </summary>
		public Ptr<NiObject> Child3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = reader.Read<ushort>();
			
			UnknownMatrix = new Matrix44();
			UnknownMatrix.Deserialize(reader);
			
			NumChildren = reader.Read<uint>();
			
			Children = new Ptr<NiAVObject>[NumChildren];
			for (var i = 0; i < NumChildren; i++)
			{
				Children[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
			Child2 = reader.Read<Ptr<NiObject>>();
			
			Child3 = reader.Read<Ptr<NiObject>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown1);
			
			writer.Write(UnknownMatrix);
			
			writer.Write(NumChildren);
			
			for (var i = 0; i < NumChildren; i++)
			{
				writer.Write(Children[i]);
			}
			
			writer.Write(Child2);
			
			writer.Write(Child3);
			
		}
	}
	

}
