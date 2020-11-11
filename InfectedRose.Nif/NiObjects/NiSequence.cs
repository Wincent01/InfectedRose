using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Root node used in some Empire Earth II .kf files (version 4.2.2.0).
	///         
	/// </summary>
	public class NiSequence : NiObject
	{
		/// <summary>
		/// Name of this object. This is also the name of the action associated with this file. For instance, if the original NIF file is called "demon.nif" and this animation file contains an attack sequence, then the file would be called "demon_attack1.kf" and this field would contain the string "attack1".
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public int UnknownInt5 { get; set; } 
		
		/// <summary>
		/// Number of controlled objects.
		/// </summary>
		public uint NumControlledBlocks { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Refers to controlled objects.
		/// </summary>
		public ControllerLink[] ControlledBlocks { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			UnknownInt4 = reader.Read<int>();
			
			UnknownInt5 = reader.Read<int>();
			
			NumControlledBlocks = reader.Read<uint>();
			
			UnknownInt1 = reader.Read<uint>();
			
			ControlledBlocks = new ControllerLink[NumControlledBlocks];
			for (var i = 0; i < NumControlledBlocks; i++)
			{
				var value = new ControllerLink();
				value.Deserialize(reader);
				ControlledBlocks[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownInt5);
			
			writer.Write(NumControlledBlocks);
			
			writer.Write(UnknownInt1);
			
			for (var i = 0; i < NumControlledBlocks; i++)
			{
				writer.Write(ControlledBlocks[i]);
			}
			
		}
	}
	

}
