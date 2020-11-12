using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         A generic key with support for interpolation. Type 1 is normal linear interpolation, type 2 has forward and backward tangents, and type 3 has tension, bias and continuity arguments. Note that color4 and byte always seem to be of type 1.
	///         
	/// </summary>
	public struct Key<TEMPLATE> : IConstruct where TEMPLATE : IConstruct, new()
	{
		/// <summary>
		/// Time of the key.
		/// </summary>
		public float Time { get; set; } 
		
		/// <summary>
		/// The key value.
		/// </summary>
		public TEMPLATE Value { get; set; } 
		
		/// <summary>
		/// Key forward tangent.
		/// </summary>
		public TEMPLATE Forward { get; set; } 
		
		/// <summary>
		/// The key backward tangent.
		/// </summary>
		public TEMPLATE Backward { get; set; } 
		
		/// <summary>
		/// The key's TBC.
		/// </summary>
		public TBC TBC { get; set; } 
		
		public uint ARG { get; set; }

		public Key(uint arg)
		{
			ARG = arg;

			Time = 0;
			Forward = new TEMPLATE();
			Backward = new TEMPLATE();
			TBC = new TBC();
			Value = new TEMPLATE();
		}

		public void Deserialize(BitReader reader)
		{
			Time = reader.Read<float>();
			
			Value = reader.Read<TEMPLATE>();
			
			if (ARG==2)
			{
				Forward = reader.Read<TEMPLATE>();
				
			}
			if (ARG==2)
			{
				Backward = reader.Read<TEMPLATE>();
				
			}
			if (ARG==3)
			{
				TBC = new TBC();
				TBC.Deserialize(reader);
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Time);
			
			writer.Write(Value);
			
			if (ARG==2)
			{
				writer.Write(Forward);
				
			}
			if (ARG==2)
			{
				writer.Write(Backward);
				
			}
			if (ARG==3)
			{
				writer.Write(TBC);
				
			}
		}
	}
	

}
