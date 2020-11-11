using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Property of vertex colors. This object is referred to by the root object of the NIF file whenever some NiTriShapeData object has vertex colors with non-default settings; if not present, vertex colors have vertex_mode=2 and lighting_mode=1.
	///         
	/// </summary>
	public class NiVertexColorProperty : NiProperty
	{
		/// <summary>
		/// 
		///             Property flags. Appears to be unused until 20.1.0.3.
		/// 
		///             Bits 0-2: Unknown
		///             Bit 3: Lighting Mode?
		///             Bits 4-5: Vertex Mode?
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
