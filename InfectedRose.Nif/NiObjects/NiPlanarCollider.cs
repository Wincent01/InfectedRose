using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiPlanarCollider : NiParticleModifier
	{
		/// <summary>
		/// Usually 0?
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat3 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat4 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat5 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat6 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat7 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat8 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat9 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat10 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat11 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat12 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat13 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat14 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat15 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat16 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<ushort>();
			
			UnknownFloat1 = reader.Read<float>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownFloat4 = reader.Read<float>();
			
			UnknownFloat5 = reader.Read<float>();
			
			UnknownFloat6 = reader.Read<float>();
			
			UnknownFloat7 = reader.Read<float>();
			
			UnknownFloat8 = reader.Read<float>();
			
			UnknownFloat9 = reader.Read<float>();
			
			UnknownFloat10 = reader.Read<float>();
			
			UnknownFloat11 = reader.Read<float>();
			
			UnknownFloat12 = reader.Read<float>();
			
			UnknownFloat13 = reader.Read<float>();
			
			UnknownFloat14 = reader.Read<float>();
			
			UnknownFloat15 = reader.Read<float>();
			
			UnknownFloat16 = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownFloat4);
			
			writer.Write(UnknownFloat5);
			
			writer.Write(UnknownFloat6);
			
			writer.Write(UnknownFloat7);
			
			writer.Write(UnknownFloat8);
			
			writer.Write(UnknownFloat9);
			
			writer.Write(UnknownFloat10);
			
			writer.Write(UnknownFloat11);
			
			writer.Write(UnknownFloat12);
			
			writer.Write(UnknownFloat13);
			
			writer.Write(UnknownFloat14);
			
			writer.Write(UnknownFloat15);
			
			writer.Write(UnknownFloat16);
			
		}
	}
	

}
