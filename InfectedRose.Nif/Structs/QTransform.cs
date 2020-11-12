using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class QTransform : IConstruct
	{
		/// <summary>
		/// Translation.
		/// </summary>
		public Vector3 Translation { get; set; } 
		
		/// <summary>
		/// Rotation.
		/// </summary>
		public Quaternion Rotation { get; set; } 
		
		/// <summary>
		/// Scale.
		/// </summary>
		public float Scale { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Rotation = new Quaternion();
			Rotation.Deserialize(reader);
			
			Scale = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Translation);
			
			writer.Write(Rotation);
			
			writer.Write(Scale);
			
		}
	}
	

}
