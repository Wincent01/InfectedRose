using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An interpolator for storing transform keyframes via a B-spline.
	///         
	/// </summary>
	public class NiBSplineTransformInterpolator : NiBSplineInterpolator
	{
		/// <summary>
		/// Base translation when translate curve not defined.
		/// </summary>
		public Vector3 Translation { get; set; } 
		
		/// <summary>
		/// Base rotation when rotation curve not defined.
		/// </summary>
		public Quaternion Rotation { get; set; } 
		
		/// <summary>
		/// Base scale when scale curve not defined.
		/// </summary>
		public float Scale { get; set; } 
		
		/// <summary>
		/// Starting offset for the translation data. (USHRT_MAX for no data.)
		/// </summary>
		public uint TranslationOffset { get; set; } 
		
		/// <summary>
		/// Starting offset for the rotation data. (USHRT_MAX for no data.)
		/// </summary>
		public uint RotationOffset { get; set; } 
		
		/// <summary>
		/// Starting offset for the scale data. (USHRT_MAX for no data.)
		/// </summary>
		public uint ScaleOffset { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Rotation = new Quaternion();
			Rotation.Deserialize(reader);
			
			Scale = reader.Read<float>();
			
			TranslationOffset = reader.Read<uint>();
			
			RotationOffset = reader.Read<uint>();
			
			ScaleOffset = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Translation);
			
			writer.Write(Rotation);
			
			writer.Write(Scale);
			
			writer.Write(TranslationOffset);
			
			writer.Write(RotationOffset);
			
			writer.Write(ScaleOffset);
			
		}
	}
	

}
