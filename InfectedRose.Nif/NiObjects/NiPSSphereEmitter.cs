using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSSphereEmitter : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString Name { get; set; } 
		
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
		public float Unknown6 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown7 { get; set; } 
		
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
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown11 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown12 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown13 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown14 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown15 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown16 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown17 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown18 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown19 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public short Unknown20 { get; set; } 
		
		/// <summary>
		/// Target node?
		/// </summary>
		public int Unknown21 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown22 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			Unknown2 = reader.Read<int>();
			
			Unknown3 = reader.Read<int>();
			
			Unknown4 = reader.Read<int>();
			
			Unknown5 = reader.Read<int>();
			
			Unknown6 = reader.Read<float>();
			
			Unknown7 = reader.Read<int>();
			
			Unknown8 = reader.Read<float>();
			
			Unknown9 = reader.Read<float>();
			
			Unknown10 = reader.Read<int>();
			
			Unknown11 = reader.Read<float>();
			
			Unknown12 = reader.Read<int>();
			
			Unknown13 = reader.Read<int>();
			
			Unknown14 = reader.Read<int>();
			
			Unknown15 = reader.Read<int>();
			
			Unknown16 = reader.Read<int>();
			
			Unknown17 = reader.Read<float>();
			
			Unknown18 = reader.Read<int>();
			
			Unknown19 = reader.Read<int>();
			
			Unknown20 = reader.Read<short>();
			
			Unknown21 = reader.Read<int>();
			
			Unknown22 = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
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
			
			writer.Write(Unknown13);
			
			writer.Write(Unknown14);
			
			writer.Write(Unknown15);
			
			writer.Write(Unknown16);
			
			writer.Write(Unknown17);
			
			writer.Write(Unknown18);
			
			writer.Write(Unknown19);
			
			writer.Write(Unknown20);
			
			writer.Write(Unknown21);
			
			writer.Write(Unknown22);
			
		}
	}
	

}
