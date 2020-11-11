using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Gives specularity to a shape. Flags 0x0001.
	///         
	/// </summary>
	public class NiSpecularProperty : NiProperty
	{
		/// <summary>
		/// 1's Bit = Enable specular lighting on this shape.
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
