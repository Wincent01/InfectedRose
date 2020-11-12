using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         The NIF file footer.
	///         
	/// </summary>
	public class Footer : IConstruct
	{
		/// <summary>
		/// The number of root references.
		/// </summary>
		public uint NumRoots { get; set; } 
		
		/// <summary>
		/// List of root NIF objects. If there is a camera, for 1st person view, then this NIF object is referred to as well in this list, even if it is not a root object (usually we want the camera to be attached to the Bip Head node).
		/// </summary>
		public Ptr<NiObject>[] Roots { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumRoots = reader.Read<uint>();
			
			Roots = new Ptr<NiObject>[NumRoots];
			for (var i = 0; i < NumRoots; i++)
			{
				Roots[i] = reader.Read<Ptr<NiObject>>();
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumRoots);
			
			for (var i = 0; i < NumRoots; i++)
			{
				writer.Write(Roots[i]);
			}
			
		}
	}
	

}
