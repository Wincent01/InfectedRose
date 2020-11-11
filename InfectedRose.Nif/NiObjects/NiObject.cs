using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Abstract object type.
	///     
	/// </summary>
	public abstract class NiObject : IConstruct
	{
		public virtual void Deserialize(BitReader reader)
		{
		}
	
		public virtual void Serialize(BitWriter writer)
		{
		}
	}
	

}
