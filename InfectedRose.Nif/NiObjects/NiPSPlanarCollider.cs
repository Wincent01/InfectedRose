using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSPlanarCollider : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnknownInt2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public short UnknownShort3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte UnknownByte4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float[] UnknownFloats5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiNode> UnknownLink6 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			UnknownInt1 = reader.Read<int>();
			
			UnknownInt2 = reader.Read<int>();
			
			UnknownShort3 = reader.Read<short>();
			
			UnknownByte4 = reader.Read<byte>();
			
			UnknownFloats5 = new float[8];
			for (var i = 0; i < 8; i++)
			{
				UnknownFloats5[i] = reader.Read<float>();
			}
			
			UnknownLink6 = reader.Read<Ptr<NiNode>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownShort3);
			
			writer.Write(UnknownByte4);
			
			for (var i = 0; i < 8; i++)
			{
				writer.Write(UnknownFloats5[i]);
			}
			
			writer.Write(UnknownLink6);
			
		}
	}
	

}
