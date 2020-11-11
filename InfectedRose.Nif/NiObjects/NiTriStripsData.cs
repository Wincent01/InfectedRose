using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Holds mesh data using strips of triangles.
	///         
	/// </summary>
	public class NiTriStripsData : NiTriBasedGeomData
	{
		/// <summary>
		/// Number of OpenGL triangle strips that are present.
		/// </summary>
		public ushort NumStrips { get; set; } 
		
		/// <summary>
		/// The number of points in each triangle strip.
		/// </summary>
		public ushort[] StripLengths { get; set; } 
		
		/// <summary>
		/// Do we have strip point data?
		/// </summary>
		public bool HasPoints { get; set; } 
		
		/// <summary>
		/// The points in the Triangle strips. Size is the sum of all entries in Strip Lengths.
		/// </summary>
		public ushort[][] Points { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumStrips = reader.Read<ushort>();
			
			StripLengths = new ushort[NumStrips];
			for (var i = 0; i < NumStrips; i++)
			{
				StripLengths[i] = reader.Read<ushort>();
			}
			
			HasPoints = reader.Read<byte>() != 0;
			
			if (HasPoints)
			{
				Points = new ushort[NumStrips][];
				for (var i = 0; i < NumStrips; i++)
				{
					var length = StripLengths[i];
					Points[i] = new ushort[length];
					for (var j = 0; j < length; j++)
					{
						Points[i][j] = reader.Read<ushort>();
					}
				}
				
			}
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumStrips);
			
			for (var i = 0; i < NumStrips; i++)
			{
				writer.Write(StripLengths[i]);
			}
			
			writer.Write((byte) (HasPoints ? 1 : 0));
			
			if (HasPoints)
			{
				for (var i = 0; i < NumStrips; i++)
				{
					var length = StripLengths[i];
					for (var j = 0; j < length; j++)
					{
						writer.Write(Points[i][j]);
					}
				}
				
			}
		}
	}
	

}
