using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         An interpolator for transform keyframes.
	///         
	/// </summary>
	public class NiTransformInterpolator : NiKeyBasedInterpolator
	{
		/// <summary>
		/// Translate.
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
		
		/// <summary>
		/// Refers to NiTransformData.
		/// </summary>
		public Ptr<NiTransformData> Data { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Rotation = new Quaternion();
			Rotation.Deserialize(reader);
			
			Scale = reader.Read<float>();
			
			Data = reader.Read<Ptr<NiTransformData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Translation);
			
			writer.Write(Rotation);
			
			writer.Write(Scale);
			
			writer.Write(Data);
			
		}
	}
	

}
