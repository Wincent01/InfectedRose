using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiSphericalCollider : NiParticleModifier
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort1 { get; set; } 
		
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
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFloat1 = reader.Read<float>();
			
			UnknownShort1 = reader.Read<ushort>();
			
			UnknownFloat2 = reader.Read<float>();
			
			UnknownFloat3 = reader.Read<float>();
			
			UnknownFloat4 = reader.Read<float>();
			
			UnknownFloat5 = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownShort1);
			
			writer.Write(UnknownFloat2);
			
			writer.Write(UnknownFloat3);
			
			writer.Write(UnknownFloat4);
			
			writer.Write(UnknownFloat5);
			
		}
	}
	

}
