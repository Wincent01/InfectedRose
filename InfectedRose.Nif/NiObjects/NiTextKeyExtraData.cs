using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Extra data, used to name different animation sequences.
	///         
	/// </summary>
	public class NiTextKeyExtraData : NiExtraData
	{
		/// <summary>
		/// The number of text keys that follow.
		/// </summary>
		public uint NumTextKeys { get; set; } 
		
		/// <summary>
		/// List of textual notes and at which time they take effect. Used for designating the start and stop of animations and the triggering of sounds.
		/// </summary>
		public Key<NiConstruct<uint>>[] TextKeys { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumTextKeys = reader.Read<uint>();
			
			TextKeys = new Key<NiConstruct<uint>>[NumTextKeys];
			for (var i = 0; i < NumTextKeys; i++)
			{
				var value = new Key<NiConstruct<uint>>(1);
				value.Deserialize(reader);
				TextKeys[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumTextKeys);
			
			for (var i = 0; i < NumTextKeys; i++)
			{
				writer.Write(TextKeys[i]);
			}
			
		}
	}
	

}
