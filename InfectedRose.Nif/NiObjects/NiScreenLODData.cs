using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes levels of detail based on size of object on screen?
	///         
	/// </summary>
	public class NiScreenLODData : NiLODData
	{
		/// <summary>
		/// The center of the bounding sphere?
		/// </summary>
		public Vector3 BoundCenter { get; set; } 
		
		/// <summary>
		/// The radius of the bounding sphere?
		/// </summary>
		public float BoundRadius { get; set; } 
		
		/// <summary>
		/// The center of the bounding sphere in world space?
		/// </summary>
		public Vector3 WorldCenter { get; set; } 
		
		/// <summary>
		/// The radius of the bounding sphere in world space?
		/// </summary>
		public float WorldRadius { get; set; } 
		
		/// <summary>
		/// The number of screen size based LOD levels.
		/// </summary>
		public uint ProportionCount { get; set; } 
		
		/// <summary>
		/// The LOD levels based on proportion of screen size?
		/// </summary>
		public float[] ProportionLevels { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			BoundCenter = new Vector3();
			BoundCenter.Deserialize(reader);
			
			BoundRadius = reader.Read<float>();
			
			WorldCenter = new Vector3();
			WorldCenter.Deserialize(reader);
			
			WorldRadius = reader.Read<float>();
			
			ProportionCount = reader.Read<uint>();
			
			ProportionLevels = new float[ProportionCount];
			for (var i = 0; i < ProportionCount; i++)
			{
				ProportionLevels[i] = reader.Read<float>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(BoundCenter);
			
			writer.Write(BoundRadius);
			
			writer.Write(WorldCenter);
			
			writer.Write(WorldRadius);
			
			writer.Write(ProportionCount);
			
			for (var i = 0; i < ProportionCount; i++)
			{
				writer.Write(ProportionLevels[i]);
			}
			
		}
	}
	

}
