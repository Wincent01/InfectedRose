using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSGravityForce : NiObject
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
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown13 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown14 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown15 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown16 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown17 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown18 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown19 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown20 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown21 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte Unknown22 { get; set; } 
		
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
		public float Unknown35 { get; set; } 
		
		/// <summary>
		/// Gravity node?
		/// </summary>
		public Ptr<NiObject> Unknown36 { get; set; } 
		
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
			
			Unknown13 = reader.Read<byte>();
			
			Unknown14 = reader.Read<byte>();
			
			Unknown15 = reader.Read<byte>();
			
			Unknown16 = reader.Read<byte>();
			
			Unknown17 = reader.Read<byte>();
			
			Unknown18 = reader.Read<float>();
			
			Unknown19 = reader.Read<byte>();
			
			Unknown20 = reader.Read<byte>();
			
			Unknown21 = reader.Read<byte>();
			
			Unknown22 = reader.Read<byte>();
			
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
			
			Unknown35 = reader.Read<float>();
			
			Unknown36 = reader.Read<Ptr<NiObject>>();
			
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
			
		}
	}
	

}
