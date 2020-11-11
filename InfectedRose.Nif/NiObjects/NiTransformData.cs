using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Mesh animation keyframe data.
	///     
	/// </summary>
	public class NiTransformData : NiKeyframeData
	{
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
		}
	}
	

}
