using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSBombForce : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown6 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown7 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown8 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown9 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown10 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			Unknown1 = reader.Read<byte>();
			
			Unknown2 = reader.Read<int>();
			
			Unknown3 = reader.Read<int>();
			
			Unknown4 = reader.Read<int>();
			
			Unknown5 = reader.Read<int>();
			
			Unknown6 = reader.Read<int>();
			
			Unknown7 = reader.Read<int>();
			
			Unknown8 = reader.Read<int>();
			
			Unknown9 = reader.Read<int>();
			
			Unknown10 = reader.Read<int>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
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
