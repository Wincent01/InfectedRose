using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A Portal
	///         
	/// </summary>
	public class NiPortal : NiAVObject
	{
		/// <summary>
		/// Unknown flags.
		/// </summary>
		public ushort UnknownFlags { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public short UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Number of vertices in this polygon
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// Vertices
		/// </summary>
		public Vector3[] Vertices { get; set; } 
		
		/// <summary>
		/// Target portal or room
		/// </summary>
		public Ptr<NiNode> Target { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFlags = reader.Read<ushort>();
			
			UnknownShort2 = reader.Read<short>();
			
			NumVertices = reader.Read<ushort>();
			
			Vertices = new Vector3[NumVertices];
			for (var i = 0; i < NumVertices; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Vertices[i] = value;
			}
			
			Target = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownFlags);
			
			writer.Write(UnknownShort2);
			
			writer.Write(NumVertices);
			
			for (var i = 0; i < NumVertices; i++)
			{
				writer.Write(Vertices[i]);
			}
			
			writer.Write(Target);
			
		}
	}
	

}
