using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes... fog?
	///         
	/// </summary>
	public class NiFogProperty : NiProperty
	{
		/// <summary>
		/// 
		///             1's bit: Enables Fog
		///             2's bit: Sets Fog Function to FOG_RANGE_SQ
		///             4's bit: Sets Fog Function to FOG_VERTEX_ALPHA
		/// 
		///             If 2's and 4's bit are not set, but fog is enabled, Fog function is FOG_Z_LINEAR.
		///         
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// The thickness of the fog?  Default is 1.0
		/// </summary>
		public float FogDepth { get; set; } 
		
		/// <summary>
		/// The color of the fog.
		/// </summary>
		public Color3 FogColor { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			FogDepth = reader.Read<float>();
			
			FogColor = new Color3();
			FogColor.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(FogDepth);
			
			writer.Write(FogColor);
			
		}
	}
	

}
