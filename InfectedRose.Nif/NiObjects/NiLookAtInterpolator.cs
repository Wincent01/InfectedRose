using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiLookAtInterpolator : NiInterpolator
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Refers to a Node to focus on.
		/// </summary>
		public Ptr<NiNode> LookAt { get; set; } 
		
		/// <summary>
		/// Target node name.
		/// </summary>
		public NiString Target { get; set; } 
		
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
		/// Refers to NiPoint3Interpolator.
		/// </summary>
		public Ptr<NiPoint3Interpolator> UnknownLink1 { get; set; } 
		
		/// <summary>
		/// Refers to a NiFloatInterpolator.
		/// </summary>
		public Ptr<NiFloatInterpolator> UnknownLink2 { get; set; } 
		
		/// <summary>
		/// Refers to a NiFloatInterpolator.
		/// </summary>
		public Ptr<NiFloatInterpolator> UnknownLink3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownShort = reader.Read<ushort>();
			
			LookAt = reader.Read<Ptr<NiNode>>();
			
			Target = new NiString();
			Target.Deserialize(reader);
			
			Translation = new Vector3();
			Translation.Deserialize(reader);
			
			Rotation = new Quaternion();
			Rotation.Deserialize(reader);
			
			Scale = reader.Read<float>();
			
			UnknownLink1 = reader.Read<Ptr<NiPoint3Interpolator>>();
			
			UnknownLink2 = reader.Read<Ptr<NiFloatInterpolator>>();
			
			UnknownLink3 = reader.Read<Ptr<NiFloatInterpolator>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownShort);
			
			writer.Write(LookAt);
			
			writer.Write(Target);
			
			writer.Write(Translation);
			
			writer.Write(Rotation);
			
			writer.Write(Scale);
			
			writer.Write(UnknownLink1);
			
			writer.Write(UnknownLink2);
			
			writer.Write(UnknownLink3);
			
		}
	}
	

}
