using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         This Property controls the Z buffer (OpenGL: depth buffer).
	///         
	/// </summary>
	public class NiZBufferProperty : NiProperty
	{
		/// <summary>
		/// 
		///             Bit 0 enables the z test
		///             Bit 1 controls wether the Z buffer is read only (0) or read/write (1)
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
