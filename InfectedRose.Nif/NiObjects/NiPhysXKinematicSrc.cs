using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXKinematicSrc : NiObject
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public byte[] UnknownBytes { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownBytes = new byte[6];
			for (var i = 0; i < 6; i++)
			{
				UnknownBytes[i] = reader.Read<byte>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 6; i++)
			{
				writer.Write(UnknownBytes[i]);
			}
			
		}
	}
	

}
