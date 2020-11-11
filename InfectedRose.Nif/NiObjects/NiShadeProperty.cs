using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Determines whether flat shading or smooth shading is used on a shape.
	///         
	/// </summary>
	public class NiShadeProperty : NiProperty
	{
		/// <summary>
		/// 
		///             1's Bit:  Enable smooth phong shading on this shape.
		/// 
		///             If 1's bit is not set, hard-edged flat shading will be used on this shape.
		///         
		/// </summary>
		public ushort Flags { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
		}
	}
	

}
