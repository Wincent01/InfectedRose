using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSDragForce : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public int Unknown1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown6 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown7 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown8 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown9 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown10 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = reader.Read<int>();
			
			Unknown2 = reader.Read<int>();
			
			Unknown3 = reader.Read<byte>();
			
			Unknown4 = reader.Read<float>();
			
			Unknown5 = reader.Read<float>();
			
			Unknown6 = reader.Read<float>();
			
			Unknown7 = reader.Read<float>();
			
			Unknown8 = reader.Read<float>();
			
			Unknown9 = reader.Read<float>();
			
			Unknown10 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown1);
			
			writer.Write(Unknown2);
			
			writer.Write(Unknown3);
			
			writer.Write(Unknown4);
			
			writer.Write(Unknown5);
			
			writer.Write(Unknown6);
			
			writer.Write(Unknown7);
			
			writer.Write(Unknown8);
			
			writer.Write(Unknown9);
			
			writer.Write(Unknown10);
			
		}
	}
	

}
