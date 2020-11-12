using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Geometry morphing data component.
	///         
	/// </summary>
	public class Morph : IConstruct
	{
		/// <summary>
		/// Name of the frame.
		/// </summary>
		public NiString FrameName { get; set; } 
		
		/// <summary>
		/// Morph vectors.
		/// </summary>
		public Vector3[] Vectors { get; set; }

		public uint ARG { get; set; }

		public Morph(uint arg)
		{
			ARG = arg;
			FrameName = new NiString();
			Vectors = new Vector3[0];
		}
		
		public void Deserialize(BitReader reader)
		{
			FrameName = new NiString();
			FrameName.Deserialize(reader);
			
			Vectors = new Vector3[ARG];
			for (var i = 0; i < ARG; i++)
			{
				var value = new Vector3();
				value.Deserialize(reader);
				Vectors[i] = value;
			}
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(FrameName);
			
			for (var i = 0; i < ARG; i++)
			{
				writer.Write(Vectors[i]);
			}
			
		}
	}
	

}
