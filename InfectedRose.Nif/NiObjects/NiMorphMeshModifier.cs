using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Performs linear-weighted blending between a set of target data streams.
	///         
	/// </summary>
	public class NiMorphMeshModifier : NiMeshModifier
	{
		/// <summary>
		/// 
		///             FLAG_RELATIVETARGETS = 0x01
		///             FLAG_UPDATENORMALS   = 0x02
		///             FLAG_NEEDSUPDATE     = 0x04
		///             FLAG_ALWAYSUPDATE    = 0x08
		///             FLAG_NEEDSCOMPLETION = 0x10
		///             FLAG_SKINNED         = 0x20
		///             FLAG_SWSKINNED       = 0x40
		///         
		/// </summary>
		public byte Flags { get; set; } 
		
		/// <summary>
		/// The number of morph targets.
		/// </summary>
		public ushort NumTargets { get; set; } 
		
		/// <summary>
		/// The number of morphing data stream elements.
		/// </summary>
		public uint NumElements { get; set; } 
		
		/// <summary>
		/// Semantics and normalization of the morphing data stream elements.
		/// </summary>
		public ElementReference[] Elements { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<byte>();
			
			NumTargets = reader.Read<ushort>();
			
			NumElements = reader.Read<uint>();
			
			Elements = new ElementReference[NumElements];
			for (var i = 0; i < NumElements; i++)
			{
				var value = new ElementReference();
				value.Deserialize(reader);
				Elements[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(NumTargets);
			
			writer.Write(NumElements);
			
			for (var i = 0; i < NumElements; i++)
			{
				writer.Write(Elements[i]);
			}
			
		}
	}
	

}
