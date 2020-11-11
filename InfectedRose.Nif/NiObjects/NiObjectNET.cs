using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An object that can be controlled by a controller.
	///         
	/// </summary>
	public abstract class NiObjectNET : NiObject
	{
		/// <summary>
		/// Name of this controllable object, used to refer to the object in .kf files.
		/// </summary>
		public NiString Name { get; set; } 
		
		/// <summary>
		/// The number of Extra Data objects referenced through the list.
		/// </summary>
		public uint NumExtraDataList { get; set; } 
		
		/// <summary>
		/// List of extra data indices.
		/// </summary>
		public Ptr<NiExtraData>[] ExtraDataList { get; set; } 
		
		/// <summary>
		/// Controller object index. (The first in a chain)
		/// </summary>
		public Ptr<NiTimeController> Controller { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Name = new NiString();
			Name.Deserialize(reader);
			
			NumExtraDataList = reader.Read<uint>();
			
			ExtraDataList = new Ptr<NiExtraData>[NumExtraDataList];
			for (var i = 0; i < NumExtraDataList; i++)
			{
				ExtraDataList[i] = reader.Read<Ptr<NiExtraData>>();
			}
			
			Controller = reader.Read<Ptr<NiTimeController>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Name);
			
			writer.Write(NumExtraDataList);
			
			for (var i = 0; i < NumExtraDataList; i++)
			{
				writer.Write(ExtraDataList[i]);
			}
			
			writer.Write(Controller);
			
		}
	}
	

}
