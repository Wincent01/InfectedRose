using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Color data for material color controller.
	///         
	/// </summary>
	public class NiColorData : NiObject
	{
		/// <summary>
		/// The color keys.
		/// </summary>
		public KeyGroup<Color4> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Data = new KeyGroup<Color4>();
			Data.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Data);
			
		}
	}
	

}
