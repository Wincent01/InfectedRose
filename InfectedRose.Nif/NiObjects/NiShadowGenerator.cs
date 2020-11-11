using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiShadowGenerator : NiObject
	{
		/// <summary>
		/// 
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort UnknownFlags { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public uint NumUnknownLinks1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiNode>[] UnknownLinks1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnkownInt2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiLight> Target { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float UnkownFloat4 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte UnkownByte5 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnkownInt6 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnkownInt7 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public int UnkownInt8 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public byte UnkownByte9 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			UnknownFlags = reader.Read<ushort>();
			
			NumUnknownLinks1 = reader.Read<uint>();
			
			UnknownLinks1 = new Ptr<NiNode>[NumUnknownLinks1];
			for (var i = 0; i < NumUnknownLinks1; i++)
			{
				UnknownLinks1[i] = reader.Read<Ptr<NiNode>>();
			}
			
			UnkownInt2 = reader.Read<int>();
			
			Target = reader.Read<Ptr<NiLight>>();
			
			UnkownFloat4 = reader.Read<float>();
			
			UnkownByte5 = reader.Read<byte>();
			
			UnkownInt6 = reader.Read<int>();
			
			UnkownInt7 = reader.Read<int>();
			
			UnkownInt8 = reader.Read<int>();
			
			UnkownByte9 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
			writer.Write(UnknownFlags);
			
			writer.Write(NumUnknownLinks1);
			
			for (var i = 0; i < NumUnknownLinks1; i++)
			{
				writer.Write(UnknownLinks1[i]);
			}
			
			writer.Write(UnkownInt2);
			
			writer.Write(Target);
			
			writer.Write(UnkownFloat4);
			
			writer.Write(UnkownByte5);
			
			writer.Write(UnkownInt6);
			
			writer.Write(UnkownInt7);
			
			writer.Write(UnkownInt8);
			
			writer.Write(UnkownByte9);
			
		}
	}
	

}
