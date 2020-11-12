using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Array of vector keys (anything that can be interpolated, except rotations).
	///         
	/// </summary>
	public class KeyGroup<TEMPLATE> : IConstruct where TEMPLATE : IConstruct, new()
	{
		/// <summary>
		/// Number of keys in the array.
		/// </summary>
		public uint NumKeys { get; set; } 
		
		/// <summary>
		/// The key type.
		/// </summary>
		public KeyType Interpolation { get; set; } 
		
		/// <summary>
		/// The keys.
		/// </summary>
		public Key<TEMPLATE>[] Keys { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumKeys = reader.Read<uint>();
			
			if (NumKeys!=0)
			{
				Interpolation = (KeyType) reader.Read<uint>();
				
			}
			Keys = new Key<TEMPLATE>[NumKeys];
			for (var i = 0; i < NumKeys; i++)
			{
				var value = new Key<TEMPLATE>((uint) Interpolation);
				value.Deserialize(reader);
				Keys[i] = value;
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumKeys);
			
			if (NumKeys!=0)
			{
				writer.Write((uint) Interpolation);
				
			}
			for (var i = 0; i < NumKeys; i++)
			{
				writer.Write(Keys[i]);
			}
			
		}
	}
	

}
