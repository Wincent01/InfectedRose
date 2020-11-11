using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSMeshEmitter : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString Name { get; set; } 
		
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
		public int Unknown3 { get; set; } 
		
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
		public float Unknown10 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown11 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown12 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown13 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown14 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown15 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown16 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown17 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown18 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public short Unknown19 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown20 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown21 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown22 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown23 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown24 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown25 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int Unknown26 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			Unknown1 = reader.Read<int>();
			
			Unknown2 = reader.Read<int>();
			
			Unknown3 = reader.Read<int>();
			
			Unknown4 = reader.Read<float>();
			
			Unknown5 = reader.Read<float>();
			
			Unknown6 = reader.Read<float>();
			
			Unknown7 = reader.Read<int>();
			
			Unknown8 = reader.Read<float>();
			
			Unknown9 = reader.Read<float>();
			
			Unknown10 = reader.Read<float>();
			
			Unknown11 = reader.Read<float>();
			
			Unknown12 = reader.Read<float>();
			
			Unknown13 = reader.Read<int>();
			
			Unknown14 = reader.Read<float>();
			
			Unknown15 = reader.Read<float>();
			
			Unknown16 = reader.Read<float>();
			
			Unknown17 = reader.Read<int>();
			
			Unknown18 = reader.Read<int>();
			
			Unknown19 = reader.Read<short>();
			
			Unknown20 = reader.Read<int>();
			
			Unknown21 = reader.Read<int>();
			
			Unknown22 = reader.Read<float>();
			
			Unknown23 = reader.Read<int>();
			
			Unknown24 = reader.Read<int>();
			
			Unknown25 = reader.Read<int>();
			
			Unknown26 = reader.Read<int>();
			
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
			
			writer.Write(Unknown23);
			
			writer.Write(Unknown24);
			
			writer.Write(Unknown25);
			
			writer.Write(Unknown26);
			
		}
	}
	

}
