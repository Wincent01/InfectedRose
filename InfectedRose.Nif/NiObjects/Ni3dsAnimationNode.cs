using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown. Only found in 2.3 nifs.
	///         
	/// </summary>
	public class Ni3dsAnimationNode : NiObject
	{
		/// <summary>
		/// Name of this object.
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public bool HasData { get; set; } 
		
		/// <summary>
		/// Unknown. Matrix?
		/// </summary>
		public float[] UnknownFloats1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Child?
		/// </summary>
		public Ptr<NiObject> Child { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float[] UnknownFloats2 { get; set; } 
		
		/// <summary>
		/// A count.
		/// </summary>
		public uint Count { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte[,] UnknownArray { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			HasData = reader.Read<byte>() != 0;
			
			if (HasData)
			{
				UnknownFloats1 = new float[21];
				for (var i = 0; i < 21; i++)
				{
					UnknownFloats1[i] = reader.Read<float>();
				}
				
			}
			if (HasData)
			{
				UnknownShort = reader.Read<ushort>();
				
			}
			if (HasData)
			{
				Child = reader.Read<Ptr<NiObject>>();
				
			}
			if (HasData)
			{
				UnknownFloats2 = new float[12];
				for (var i = 0; i < 12; i++)
				{
					UnknownFloats2[i] = reader.Read<float>();
				}
				
			}
			if (HasData)
			{
				Count = reader.Read<uint>();
				
			}
			if (HasData)
			{
				UnknownArray = new byte[Count, 5];
				for (var i = 0; i < Count; i++)
				{
					for (var j = 0; j < 5; j++)
					{
						UnknownArray[i, j] = reader.Read<byte>();
					}
				}
				
			}
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
			writer.Write((byte) (HasData ? 1 : 0));
			
			if (HasData)
			{
				for (var i = 0; i < 21; i++)
				{
					writer.Write(UnknownFloats1[i]);
				}
				
			}
			if (HasData)
			{
				writer.Write(UnknownShort);
				
			}
			if (HasData)
			{
				writer.Write(Child);
				
			}
			if (HasData)
			{
				for (var i = 0; i < 12; i++)
				{
					writer.Write(UnknownFloats2[i]);
				}
				
			}
			if (HasData)
			{
				writer.Write(Count);
				
			}
			if (HasData)
			{
				for (var i = 0; i < Count; i++)
				{
					for (var j = 0; j < 5; j++)
					{
						writer.Write(UnknownArray[i, j]);
					}
				}
				
			}
		}
	}
	

}
