using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Not used in skinning.
	///         Unsure of use - perhaps for morphing animation or gravity.
	///         
	/// </summary>
	public class NiVertWeightsExtraData : NiExtraData
	{
		/// <summary>
		/// Number of bytes in this data object.
		/// </summary>
		public uint NumBytes { get; set; } 
		
		/// <summary>
		/// Number of vertices.
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// The vertex weights.
		/// </summary>
		public float[] Weight { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumBytes = reader.Read<uint>();
			
			NumVertices = reader.Read<ushort>();
			
			Weight = new float[NumVertices];
			for (var i = 0; i < NumVertices; i++)
			{
				Weight[i] = reader.Read<float>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumBytes);
			
			writer.Write(NumVertices);
			
			for (var i = 0; i < NumVertices; i++)
			{
				writer.Write(Weight[i]);
			}
			
		}
	}
	

}
