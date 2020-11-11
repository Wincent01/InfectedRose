using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Visibility data for a controller.
	///         
	/// </summary>
	public class NiVisData : NiObject
	{
		/// <summary>
		/// The number of visibility keys that follow.
		/// </summary>
		public uint NumKeys { get; set; } 
		
		/// <summary>
		/// The visibility keys.
		/// </summary>
		public Key<byte>[] Keys { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumKeys = reader.Read<uint>();
			
			Keys = new Key<byte>[NumKeys];
			for (var i = 0; i < NumKeys; i++)
			{
				var value = new Key<byte>();
				value.Deserialize(reader);
				Keys[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumKeys);
			
			for (var i = 0; i < NumKeys; i++)
			{
				writer.Write(Keys[i]);
			}
			
		}
	}
	

}
