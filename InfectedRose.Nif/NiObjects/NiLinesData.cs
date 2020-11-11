using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Wireframe geometry data.
	///         
	/// </summary>
	public class NiLinesData : NiGeometryData
	{
		/// <summary>
		/// Is vertex connected to other (next?) vertex?
		/// </summary>
		public bool[] Lines { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Lines = new bool[NumVertices];
			for (var i = 0; i < NumVertices; i++)
			{
				Lines[i] = reader.Read<byte>() != 0;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < NumVertices; i++)
			{
				writer.Write((byte) (Lines[i] ? 1 : 0));
			}
			
		}
	}
	

}
