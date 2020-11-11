using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Light color animation controller.
	///     
	/// </summary>
	public class NiLightColorController : NiPoint3InterpController
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
