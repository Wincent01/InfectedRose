using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public struct SkinShapeGroup : IConstruct
	{
		/// <summary>
		/// Counts unknown.
		/// </summary>
		public uint NumLinkPairs { get; set; } 
		
		/// <summary>
		/// 
		///             First link is a NiTriShape object.
		///             Second link is a NiSkinInstance object.
		///         
		/// </summary>
		public SkinShape[] LinkPairs { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumLinkPairs = reader.Read<uint>();
			
			LinkPairs = new SkinShape[NumLinkPairs];
			for (var i = 0; i < NumLinkPairs; i++)
			{
				var value = new SkinShape();
				value.Deserialize(reader);
				LinkPairs[i] = value;
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumLinkPairs);
			
			for (var i = 0; i < NumLinkPairs; i++)
			{
				writer.Write(LinkPairs[i]);
			}
			
		}
	}
	

}
