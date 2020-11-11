using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle emitter that uses points within a defined Box shape to emit from..
	///         
	/// </summary>
	public class NiPSysBoxEmitter : NiPSysVolumeEmitter
	{
		/// <summary>
		/// Defines the Width of the box area.
		/// </summary>
		public float Width { get; set; } 
		
		/// <summary>
		/// Defines the Height of the box area.
		/// </summary>
		public float Height { get; set; } 
		
		/// <summary>
		/// Defines the Depth of the box area.
		/// </summary>
		public float Depth { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Width = reader.Read<float>();
			
			Height = reader.Read<float>();
			
			Depth = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Width);
			
			writer.Write(Height);
			
			writer.Write(Depth);
			
		}
	}
	

}
