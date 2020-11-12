using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class SkinTransform : IConstruct
	{
		/// <summary>
		/// The rotation part of the transformation matrix.
		/// </summary>
		public Matrix33 Rotation { get; set; } 
		
		/// <summary>
		/// The translation vector.
		/// </summary>
		public Vector3 Translation { get; set; } 
		
		/// <summary>
		/// Scaling part (only uniform scaling is supported).
		/// </summary>
		public float Scale { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Rotation = new Matrix33();
			Rotation.Deserialize(reader);
			
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Scale = reader.Read<float>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Rotation);
			
			writer.Write(Translation);
			
			writer.Write(Scale);
			
		}
	}
	

}
