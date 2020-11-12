using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A special version of the key type used for quaternions.  Never has tangents.
	///         
	/// </summary>
	public class QuatKey<TEMPLATE> : IConstruct where TEMPLATE : IConstruct, new()
	{
		/// <summary>
		/// Time the key applies.
		/// </summary>
		public float Time { get; set; } 
		
		/// <summary>
		/// Value of the key.
		/// </summary>
		public TEMPLATE Value { get; set; } 
		
		/// <summary>
		/// The TBC of the key.
		/// </summary>
		public TBC TBC { get; set; } 
		
		public uint ARG { get; set; }

		public QuatKey(uint arg)
		{
			ARG = arg;

			Time = 0;
			Value = new TEMPLATE();
			TBC = new TBC();
		}
		
		public void Deserialize(BitReader reader)
		{
			if (ARG!=4)
			{
				Time = reader.Read<float>();
				
			}
			if (ARG!=4)
			{
				Value = reader.Read<TEMPLATE>();
				
			}
			if (ARG==3)
			{
				TBC = new TBC();
				TBC.Deserialize(reader);
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			if (ARG!=4)
			{
				writer.Write(Time);
				
			}
			if (ARG!=4)
			{
				writer.Write(Value);
				
			}
			if (ARG==3)
			{
				writer.Write(TBC);
				
			}
		}
	}
	

}
