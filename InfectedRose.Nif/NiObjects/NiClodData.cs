using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Holds mesh data for continuous level of detail shapes.
	///         Pesumably a progressive mesh with triangles specified by edge splits.
	///         Seems to be specific to Freedom Force.
	///         The structure of this is uncertain and highly experimental at this point.
	///         No file with this data can currently be read properly.
	///         
	/// </summary>
	public class NiClodData : NiTriBasedGeomData
	{
		/// <summary>
		/// 
		/// </summary>
		public ushort UnknownShorts { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort UnknownCount1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort UnknownCount2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort UnknownCount3 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float UnknownFloat { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort[,] UnknownClodShorts1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort[] UnknownClodShorts2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public ushort[,] UnknownClodShorts3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShorts = reader.Read<ushort>();
			
			UnknownCount1 = reader.Read<ushort>();
			
			UnknownCount2 = reader.Read<ushort>();
			
			UnknownCount3 = reader.Read<ushort>();
			
			UnknownFloat = reader.Read<float>();
			
			UnknownShort = reader.Read<ushort>();
			
			UnknownClodShorts1 = new ushort[UnknownCount1, 6];
			for (var i = 0; i < UnknownCount1; i++)
			{
				for (var j = 0; j < 6; j++)
				{
					UnknownClodShorts1[i, j] = reader.Read<ushort>();
				}
			}
			
			UnknownClodShorts2 = new ushort[UnknownCount2];
			for (var i = 0; i < UnknownCount2; i++)
			{
				UnknownClodShorts2[i] = reader.Read<ushort>();
			}
			
			UnknownClodShorts3 = new ushort[UnknownCount3, 6];
			for (var i = 0; i < UnknownCount3; i++)
			{
				for (var j = 0; j < 6; j++)
				{
					UnknownClodShorts3[i, j] = reader.Read<ushort>();
				}
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShorts);
			
			writer.Write(UnknownCount1);
			
			writer.Write(UnknownCount2);
			
			writer.Write(UnknownCount3);
			
			writer.Write(UnknownFloat);
			
			writer.Write(UnknownShort);
			
			for (var i = 0; i < UnknownCount1; i++)
			{
				for (var j = 0; j < 6; j++)
				{
					writer.Write(UnknownClodShorts1[i, j]);
				}
			}
			
			for (var i = 0; i < UnknownCount2; i++)
			{
				writer.Write(UnknownClodShorts2[i]);
			}
			
			for (var i = 0; i < UnknownCount3; i++)
			{
				for (var j = 0; j < 6; j++)
				{
					writer.Write(UnknownClodShorts3[i, j]);
				}
			}
			
		}
	}
	

}
