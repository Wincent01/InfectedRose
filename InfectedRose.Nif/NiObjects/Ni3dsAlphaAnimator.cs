using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class Ni3dsAlphaAnimator : NiObject
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte[] Unknown1 { get; set; } 
		
		/// <summary>
		/// The parent?
		/// </summary>
		public Ptr<NiObject> Parent { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint Num1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint Num2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint[,] Unknown2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown1 = new byte[40];
			for (var i = 0; i < 40; i++)
			{
				Unknown1[i] = reader.Read<byte>();
			}
			
			Parent = reader.Read<Ptr<NiObject>>();
			
			Num1 = reader.Read<uint>();
			
			Num2 = reader.Read<uint>();
			
			Unknown2 = new uint[Num1, Num2];
			for (var i = 0; i < Num1; i++)
			{
				for (var j = 0; j < Num2; j++)
				{
					Unknown2[i, j] = reader.Read<uint>();
				}
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < 40; i++)
			{
				writer.Write(Unknown1[i]);
			}
			
			writer.Write(Parent);
			
			writer.Write(Num1);
			
			writer.Write(Num2);
			
			for (var i = 0; i < Num1; i++)
			{
				for (var j = 0; j < Num2; j++)
				{
					writer.Write(Unknown2[i, j]);
				}
			}
			
		}
	}
	

}
