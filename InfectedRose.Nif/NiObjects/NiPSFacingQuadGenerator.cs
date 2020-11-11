using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSFacingQuadGenerator : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown6 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown7 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown8 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown9 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown10 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown11 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown12 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = reader.Read<byte>();
			
			Unknown2 = reader.Read<byte>();
			
			Unknown3 = reader.Read<byte>();
			
			Unknown4 = reader.Read<byte>();
			
			Unknown5 = reader.Read<byte>();
			
			Unknown6 = reader.Read<byte>();
			
			Unknown7 = reader.Read<byte>();
			
			Unknown8 = reader.Read<byte>();
			
			Unknown9 = reader.Read<byte>();
			
			Unknown10 = reader.Read<byte>();
			
			Unknown11 = reader.Read<byte>();
			
			Unknown12 = reader.Read<byte>();
			
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
			
			writer.Write(Unknown11);
			
			writer.Write(Unknown12);
			
		}
	}
	

}
