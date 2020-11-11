using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSSphericalCollider : NiObject
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
		public int Unknown5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public short Unknown6 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown7 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = reader.Read<int>();
			
			Unknown2 = reader.Read<int>();
			
			Unknown3 = reader.Read<byte>();
			
			Unknown4 = reader.Read<float>();
			
			Unknown5 = reader.Read<int>();
			
			Unknown6 = reader.Read<short>();
			
			Unknown7 = reader.Read<int>();
			
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
			
		}
	}
	

}
