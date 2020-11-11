using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiPSParticleSystem : NiAVObject
	{
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int[] Unknown38 { get; set; } 
		
		/// <summary>
		/// -1?
		/// </summary>
		public int Unknown4 { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int[] Unknown39 { get; set; } 
		
		/// <summary>
		/// 256?
		/// </summary>
		public int Unknown6 { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown7 { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown8 { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown9 { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public float Unknown10 { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown11 { get; set; } 
		
		/// <summary>
		/// Counter?
		/// </summary>
		public int Unknown12 { get; set; } 
		
		/// <summary>
		/// Simulator?
		/// </summary>
		public Ptr<NiObject> Simulator { get; set; } 
		
		/// <summary>
		/// Generator?
		/// </summary>
		public Ptr<NiObject> Generator { get; set; } 
		
		/// <summary>
		/// Simulator?
		/// </summary>
		public int Unknown15 { get; set; } 
		
		/// <summary>
		/// Updater?
		/// </summary>
		public int Unknown16 { get; set; } 
		
		/// <summary>
		/// 1?
		/// </summary>
		public int Unknown17 { get; set; } 
		
		/// <summary>
		/// Emitter?
		/// </summary>
		public Ptr<NiObject> Emitter { get; set; } 
		
		/// <summary>
		/// 0?
		/// </summary>
		public int Unknown19 { get; set; } 
		
		/// <summary>
		/// Spawner?
		/// </summary>
		public int Unknown20 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int Unknown21 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte[] Unknown22 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown3 = reader.Read<int>();
			
			Unknown38 = new int[Unknown3];
			for (var i = 0; i < Unknown3; i++)
			{
				Unknown38[i] = reader.Read<int>();
			}
			
			Unknown4 = reader.Read<int>();
			
			Unknown5 = reader.Read<int>();
			
			Unknown39 = new int[Unknown3];
			for (var i = 0; i < Unknown3; i++)
			{
				Unknown39[i] = reader.Read<int>();
			}
			
			Unknown6 = reader.Read<int>();
			
			Unknown7 = reader.Read<int>();
			
			Unknown8 = reader.Read<int>();
			
			Unknown9 = reader.Read<int>();
			
			Unknown10 = reader.Read<float>();
			
			Unknown11 = reader.Read<int>();
			
			Unknown12 = reader.Read<int>();
			
			Simulator = reader.Read<Ptr<NiObject>>();
			
			if (Unknown12>1)
			{
				Generator = reader.Read<Ptr<NiObject>>();
				
			}
			Unknown15 = reader.Read<int>();
			
			Unknown16 = reader.Read<int>();
			
			Unknown17 = reader.Read<int>();
			
			Emitter = reader.Read<Ptr<NiObject>>();
			
			Unknown19 = reader.Read<int>();
			
			Unknown20 = reader.Read<int>();
			
			Unknown21 = reader.Read<int>();
			
			Unknown22 = new byte[4];
			for (var i = 0; i < 4; i++)
			{
				Unknown22[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown3);
			
			for (var i = 0; i < Unknown3; i++)
			{
				writer.Write(Unknown38[i]);
			}
			
			writer.Write(Unknown4);
			
			writer.Write(Unknown5);
			
			for (var i = 0; i < Unknown3; i++)
			{
				writer.Write(Unknown39[i]);
			}
			
			writer.Write(Unknown6);
			
			writer.Write(Unknown7);
			
			writer.Write(Unknown8);
			
			writer.Write(Unknown9);
			
			writer.Write(Unknown10);
			
			writer.Write(Unknown11);
			
			writer.Write(Unknown12);
			
			writer.Write(Simulator);
			
			if (Unknown12>1)
			{
				writer.Write(Generator);
				
			}
			writer.Write(Unknown15);
			
			writer.Write(Unknown16);
			
			writer.Write(Unknown17);
			
			writer.Write(Emitter);
			
			writer.Write(Unknown19);
			
			writer.Write(Unknown20);
			
			writer.Write(Unknown21);
			
			for (var i = 0; i < 4; i++)
			{
				writer.Write(Unknown22[i]);
			}
			
		}
	}
	

}
