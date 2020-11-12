using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Texture coordinate data.
	///         
	/// </summary>
	public class NiUVData : NiObject
	{
		/// <summary>
		/// 
		///             Four UV data groups. Appear to be U translation, V translation, U scaling/tiling, V scaling/tiling.
		///         
		/// </summary>
		public KeyGroup<NiConstruct<float>>[] UVGroups { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UVGroups = new KeyGroup<NiConstruct<float>>[4];
			for (var i = 0; i < 4; i++)
			{
				var value = new KeyGroup<NiConstruct<float>>();
				value.Deserialize(reader);
				UVGroups[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 4; i++)
			{
				writer.Write(UVGroups[i]);
			}
			
		}
	}
	

}
