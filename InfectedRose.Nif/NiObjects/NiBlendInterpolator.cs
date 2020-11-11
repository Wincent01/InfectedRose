using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An extended type of interpolater.
	///         
	/// </summary>
	public abstract class NiBlendInterpolator : NiInterpolator
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<ushort>();
			
			UnknownInt = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
			writer.Write(UnknownInt);
			
		}
	}
	

}
