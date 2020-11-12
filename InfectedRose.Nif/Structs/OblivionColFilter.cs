using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Oblivion's ColFilter property for Havok.
	///         
	/// </summary>
	public class OblivionColFilter : IConstruct
	{
		/// <summary>
		/// Sets mesh color in Oblivion Construction Set.
		/// </summary>
		public OblivionLayer Layer { get; set; } 
		
		/// <summary>
		/// The first bit sets the LINK property and controls whether this body is physically linked to others. The next bit turns collision off. Then, the next bit sets the SCALED property in Oblivion. The next five bits make up the number of this part in a linked body list.
		/// </summary>
		public byte ColFilter { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Layer = (OblivionLayer) reader.Read<byte>();
			
			ColFilter = reader.Read<byte>();
			
			UnknownShort = reader.Read<ushort>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write((byte) Layer);
			
			writer.Write(ColFilter);
			
			writer.Write(UnknownShort);
			
		}
	}
	

}
