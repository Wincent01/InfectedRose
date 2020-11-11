using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Time controller for texture coordinates.
	///         
	/// </summary>
	public class NiUVController : NiTimeController
	{
		/// <summary>
		/// Always 0?
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Texture coordinate controller data index.
		/// </summary>
		public Ptr<NiUVData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<ushort>();
			
			Data = reader.Read<Ptr<NiUVData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
			writer.Write(Data);
			
		}
	}
	

}
