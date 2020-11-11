using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Geometry morphing data.
	///         
	/// </summary>
	public class NiMorphData : NiObject
	{
		/// <summary>
		/// Number of morphing object.
		/// </summary>
		public uint NumMorphs { get; set; } 
		
		/// <summary>
		/// Number of vertices.
		/// </summary>
		public uint NumVertices { get; set; } 
		
		/// <summary>
		/// This byte is always 1 in all official files.
		/// </summary>
		public byte RelativeTargets { get; set; } 
		
		/// <summary>
		/// The geometry morphing objects.
		/// </summary>
		public Morph[] Morphs { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumMorphs = reader.Read<uint>();
			
			NumVertices = reader.Read<uint>();
			
			RelativeTargets = reader.Read<byte>();
			
			Morphs = new Morph[NumMorphs];
			for (var i = 0; i < NumMorphs; i++)
			{
				var value = new Morph();
				value.Deserialize(reader);
				Morphs[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumMorphs);
			
			writer.Write(NumVertices);
			
			writer.Write(RelativeTargets);
			
			for (var i = 0; i < NumMorphs; i++)
			{
				writer.Write(Morphs[i]);
			}
			
		}
	}
	

}
