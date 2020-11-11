using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown. Refers to a list of objects. Used by NiControllerManager.
	///         
	/// </summary>
	public class NiDefaultAVObjectPalette : NiAVObjectPalette
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Number of objects.
		/// </summary>
		public uint NumObjs { get; set; } 
		
		/// <summary>
		/// The objects.
		/// </summary>
		public AVObject[] Objs { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt = reader.Read<uint>();
			
			NumObjs = reader.Read<uint>();
			
			Objs = new AVObject[NumObjs];
			for (var i = 0; i < NumObjs; i++)
			{
				var value = new AVObject();
				value.Deserialize(reader);
				Objs[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt);
			
			writer.Write(NumObjs);
			
			for (var i = 0; i < NumObjs; i++)
			{
				writer.Write(Objs[i]);
			}
			
		}
	}
	

}
