using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSBoxEmitter : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown2 { get; set; } 
		
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
		public float Unknown7 { get; set; } 
		
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
		public float Unknown17 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown18 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown19 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown20 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown21 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown22 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown23 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown24 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown25 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown26 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown27 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown28 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown29 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown30 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown31 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown32 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown33 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown34 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown35 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown36 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown37 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown38 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown39 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown40 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown41 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown42 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown43 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown44 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown45 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown46 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown47 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown48 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			Unknown1 = reader.Read<float>();
			
			Unknown2 = reader.Read<float>();
			
			Unknown3 = reader.Read<byte>();
			
			Unknown4 = reader.Read<byte>();
			
			Unknown5 = reader.Read<byte>();
			
			Unknown6 = reader.Read<byte>();
			
			Unknown7 = reader.Read<float>();
			
			Unknown8 = reader.Read<byte>();
			
			Unknown9 = reader.Read<byte>();
			
			Unknown10 = reader.Read<byte>();
			
			Unknown11 = reader.Read<byte>();
			
			Unknown12 = reader.Read<float>();
			
			Unknown13 = reader.Read<int>();
			
			Unknown14 = reader.Read<float>();
			
			Unknown15 = reader.Read<float>();
			
			Unknown16 = reader.Read<float>();
			
			Unknown17 = reader.Read<float>();
			
			Unknown18 = reader.Read<float>();
			
			Unknown19 = reader.Read<float>();
			
			Unknown20 = reader.Read<float>();
			
			Unknown21 = reader.Read<float>();
			
			Unknown22 = reader.Read<float>();
			
			Unknown23 = reader.Read<byte>();
			
			Unknown24 = reader.Read<byte>();
			
			Unknown25 = reader.Read<byte>();
			
			Unknown26 = reader.Read<byte>();
			
			Unknown27 = reader.Read<byte>();
			
			Unknown28 = reader.Read<byte>();
			
			Unknown29 = reader.Read<byte>();
			
			Unknown30 = reader.Read<byte>();
			
			Unknown31 = reader.Read<byte>();
			
			Unknown32 = reader.Read<byte>();
			
			Unknown33 = reader.Read<byte>();
			
			Unknown34 = reader.Read<byte>();
			
			Unknown35 = reader.Read<byte>();
			
			Unknown36 = reader.Read<byte>();
			
			Unknown37 = reader.Read<byte>();
			
			Unknown38 = reader.Read<byte>();
			
			Unknown39 = reader.Read<byte>();
			
			Unknown40 = reader.Read<byte>();
			
			Unknown41 = reader.Read<byte>();
			
			Unknown42 = reader.Read<byte>();
			
			Unknown43 = reader.Read<byte>();
			
			Unknown44 = reader.Read<byte>();
			
			Unknown45 = reader.Read<byte>();
			
			Unknown46 = reader.Read<byte>();
			
			Unknown47 = reader.Read<byte>();
			
			Unknown48 = reader.Read<byte>();
			
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
			
			writer.Write(Unknown27);
			
			writer.Write(Unknown28);
			
			writer.Write(Unknown29);
			
			writer.Write(Unknown30);
			
			writer.Write(Unknown31);
			
			writer.Write(Unknown32);
			
			writer.Write(Unknown33);
			
			writer.Write(Unknown34);
			
			writer.Write(Unknown35);
			
			writer.Write(Unknown36);
			
			writer.Write(Unknown37);
			
			writer.Write(Unknown38);
			
			writer.Write(Unknown39);
			
			writer.Write(Unknown40);
			
			writer.Write(Unknown41);
			
			writer.Write(Unknown42);
			
			writer.Write(Unknown43);
			
			writer.Write(Unknown44);
			
			writer.Write(Unknown45);
			
			writer.Write(Unknown46);
			
			writer.Write(Unknown47);
			
			writer.Write(Unknown48);
			
		}
	}
	

}
