using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Used in NiDefaultAVObjectPalette.
	///         
	/// </summary>
	public struct AVObject : IConstruct
	{
		/// <summary>
		/// Object name.
		/// </summary>
		public SizedString Name { get; set; } 
		
		/// <summary>
		/// Object reference.
		/// </summary>
		public Ptr<NiAVObject> AVObjectRef { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Name = new SizedString();
			Name.Deserialize(reader);
			
			AVObjectRef = reader.Read<Ptr<NiAVObject>>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Name);
			
			writer.Write(AVObjectRef);
			
		}
	}
	

}
