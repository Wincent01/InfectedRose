using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Bounding box.
	///         
	/// </summary>
	public struct BoundingBox : IConstruct
	{
		/// <summary>
		/// Usually 1.
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Translation vector.
		/// </summary>
		public Vector3 Translation { get; set; } 
		
		/// <summary>
		/// Rotation matrix.
		/// </summary>
		public Matrix33 Rotation { get; set; } 
		
		/// <summary>
		/// Radius, per direction.
		/// </summary>
		public Vector3 Radius { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			UnknownInt = reader.Read<uint>();
			
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Rotation = new Matrix33();
			Rotation.Deserialize(reader);
			
			Radius = new Vector3();
			Radius.Deserialize(reader);
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(UnknownInt);
			
			writer.Write(Translation);
			
			writer.Write(Rotation);
			
			writer.Write(Radius);
			
		}
	}
	

}
