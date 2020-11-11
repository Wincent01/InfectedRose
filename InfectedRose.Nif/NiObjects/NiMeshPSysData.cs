using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle meshes data.
	///         
	/// </summary>
	public class NiMeshPSysData : NiPSysData
	{
		/// <summary>
		/// Unknown. Possible vertex count but probably not.
		/// </summary>
		public uint UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Unknown. 0?
		/// </summary>
		public byte UnknownByte3 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint NumUnknownInts1 { get; set; } 
		
		/// <summary>
		/// Unknown integers
		/// </summary>
		public uint[] UnknownInts1 { get; set; } 
		
		/// <summary>
		/// Unknown NiNode.
		/// </summary>
		public Ptr<NiNode> UnknownNode { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt2 = reader.Read<uint>();
			
			UnknownByte3 = reader.Read<byte>();
			
			NumUnknownInts1 = reader.Read<uint>();
			
			UnknownInts1 = new uint[NumUnknownInts1];
			for (var i = 0; i < NumUnknownInts1; i++)
			{
				UnknownInts1[i] = reader.Read<uint>();
			}
			
			UnknownNode = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownByte3);
			
			writer.Write(NumUnknownInts1);
			
			for (var i = 0; i < NumUnknownInts1; i++)
			{
				writer.Write(UnknownInts1[i]);
			}
			
			writer.Write(UnknownNode);
			
		}
	}
	

}
