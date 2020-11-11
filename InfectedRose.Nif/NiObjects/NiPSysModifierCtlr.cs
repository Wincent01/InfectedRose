using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A particle system modifier controller.
	///         
	/// </summary>
	public abstract class NiPSysModifierCtlr : NiSingleInterpController
	{
		/// <summary>
		/// Refers to modifier object by its name?
		/// </summary>
		public NiString ModifierName { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ModifierName = new NiString();
			ModifierName.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ModifierName);
			
		}
	}
	

}
