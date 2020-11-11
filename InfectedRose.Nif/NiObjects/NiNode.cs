using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Generic node object for grouping.
	///         
	/// </summary>
	public class NiNode : NiAVObject
	{
		/// <summary>
		/// The number of child objects.
		/// </summary>
		public uint NumChildren { get; set; } 
		
		/// <summary>
		/// List of child node object indices.
		/// </summary>
		public Ptr<NiAVObject>[] Children { get; set; } 
		
		/// <summary>
		/// The number of references to effect objects that follow.
		/// </summary>
		public uint NumEffects { get; set; } 
		
		/// <summary>
		/// List of node effects. ADynamicEffect?
		/// </summary>
		public Ptr<NiDynamicEffect>[] Effects { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumChildren = reader.Read<uint>();
			
			Children = new Ptr<NiAVObject>[NumChildren];
			for (var i = 0; i < NumChildren; i++)
			{
				Children[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
			NumEffects = reader.Read<uint>();
			
			Effects = new Ptr<NiDynamicEffect>[NumEffects];
			for (var i = 0; i < NumEffects; i++)
			{
				Effects[i] = reader.Read<Ptr<NiDynamicEffect>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumChildren);
			
			for (var i = 0; i < NumChildren; i++)
			{
				writer.Write(Children[i]);
			}
			
			writer.Write(NumEffects);
			
			for (var i = 0; i < NumEffects; i++)
			{
				writer.Write(Effects[i]);
			}
			
		}
	}
	

}
