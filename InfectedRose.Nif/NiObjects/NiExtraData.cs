using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A generic extra data object.
	///         
	/// </summary>
	public abstract class NiExtraData : NiObject
	{
		/// <summary>
		/// Name of this object.
		/// </summary>
		public NiString Name { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
		}
	}
	

}
