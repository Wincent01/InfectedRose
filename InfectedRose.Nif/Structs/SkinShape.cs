using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Reference to shape and skin instance.
	///         
	/// </summary>
	public class SkinShape : IConstruct
	{
		/// <summary>
		/// The shape.
		/// </summary>
		public Ptr<NiTriBasedGeom> Shape { get; set; } 
		
		/// <summary>
		/// Skinning instance for the shape?
		/// </summary>
		public Ptr<NiSkinInstance> SkinInstance { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Shape = reader.Read<Ptr<NiTriBasedGeom>>();
			
			SkinInstance = reader.Read<Ptr<NiSkinInstance>>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Shape);
			
			writer.Write(SkinInstance);
			
		}
	}
	

}
