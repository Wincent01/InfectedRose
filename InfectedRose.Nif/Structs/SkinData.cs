using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Skinning data component.
	///         
	/// </summary>
	public class SkinData : IConstruct
	{
		/// <summary>
		/// Offset of the skin from this bone in bind position.
		/// </summary>
		public SkinTransform SkinTransform { get; set; } 
		
		/// <summary>
		/// Translation offset of a bounding sphere holding all vertices. (Note that its a Sphere Containing Axis Aligned Box not a minimum volume Sphere)
		/// </summary>
		public Vector3 BoundingSphereOffset { get; set; } 
		
		/// <summary>
		/// Radius for bounding sphere holding all vertices.
		/// </summary>
		public float BoundingSphereRadius { get; set; } 
		
		/// <summary>
		/// Unknown, always 0?
		/// </summary>
		public short[] Unknown13Shorts { get; set; } 
		
		/// <summary>
		/// Number of weighted vertices.
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// The vertex weights.
		/// </summary>
		public SkinWeight[] VertexWeights { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			SkinTransform = new SkinTransform();
			SkinTransform.Deserialize(reader);
			
			BoundingSphereOffset = new Vector3();
			BoundingSphereOffset.Deserialize(reader);
			
			BoundingSphereRadius = reader.Read<float>();
			
			Unknown13Shorts = new short[13];
			for (var i = 0; i < 13; i++)
			{
				Unknown13Shorts[i] = reader.Read<short>();
			}
			
			NumVertices = reader.Read<ushort>();
			
				VertexWeights = new SkinWeight[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new SkinWeight();
					value.Deserialize(reader);
					VertexWeights[i] = value;
				}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(SkinTransform);
			
			writer.Write(BoundingSphereOffset);
			
			writer.Write(BoundingSphereRadius);
			
			for (var i = 0; i < 13; i++)
			{
				writer.Write(Unknown13Shorts[i]);
			}
			
			writer.Write(NumVertices);
			
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(VertexWeights[i]);
				}
		}
	}
	

}
