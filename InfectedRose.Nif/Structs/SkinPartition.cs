using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Skinning data for a submesh, optimized for hardware skinning. Part of NiSkinPartition.
	///         
	/// </summary>
	public class SkinPartition : IConstruct
	{
		/// <summary>
		/// Number of vertices in this submesh.
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// Number of triangles in this submesh.
		/// </summary>
		public ushort NumTriangles { get; set; } 
		
		/// <summary>
		/// Number of bones influencing this submesh.
		/// </summary>
		public ushort NumBones { get; set; } 
		
		/// <summary>
		/// Number of strips in this submesh (zero if not stripped).
		/// </summary>
		public ushort NumStrips { get; set; } 
		
		/// <summary>
		/// Number of weight coefficients per vertex. The Gamebryo engine seems to work well only if this number is equal to 4, even if there are less than 4 influences per vertex.
		/// </summary>
		public ushort NumWeightsPerVertex { get; set; } 
		
		/// <summary>
		/// List of bones.
		/// </summary>
		public ushort[] Bones { get; set; } 
		
		/// <summary>
		/// Do we have a vertex map?
		/// </summary>
		public bool HasVertexMap { get; set; } 
		
		/// <summary>
		/// Maps the weight/influence lists in this submesh to the vertices in the shape being skinned.
		/// </summary>
		public ushort[] VertexMap { get; set; } 
		
		/// <summary>
		/// Do we have vertex weights?
		/// </summary>
		public bool HasVertexWeights { get; set; } 
		
		/// <summary>
		/// The vertex weights.
		/// </summary>
		public float[,] VertexWeights { get; set; } 
		
		/// <summary>
		/// The strip lengths.
		/// </summary>
		public ushort[] StripLengths { get; set; } 
		
		/// <summary>
		/// Do we have triangle or strip data?
		/// </summary>
		public bool HasFaces { get; set; } 
		
		/// <summary>
		/// The strips.
		/// </summary>
		public ushort[][] Strips { get; set; } 
		
		/// <summary>
		/// The triangles.
		/// </summary>
		public Triangle[] Triangles { get; set; } 
		
		/// <summary>
		/// Do we have bone indices?
		/// </summary>
		public bool HasBoneIndices { get; set; } 
		
		/// <summary>
		/// Bone indices, they index into 'Bones'.
		/// </summary>
		public byte[,] BoneIndices { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			NumVertices = reader.Read<ushort>();
			
			NumTriangles = reader.Read<ushort>();
			
			NumBones = reader.Read<ushort>();
			
			NumStrips = reader.Read<ushort>();
			
			NumWeightsPerVertex = reader.Read<ushort>();
			
			Bones = new ushort[NumBones];
			for (var i = 0; i < NumBones; i++)
			{
				Bones[i] = reader.Read<ushort>();
			}
			
			HasVertexMap = reader.Read<byte>() != 0;
			
			if (HasVertexMap)
			{
				VertexMap = new ushort[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					VertexMap[i] = reader.Read<ushort>();
				}
				
			}
			HasVertexWeights = reader.Read<byte>() != 0;
			
			if (HasVertexWeights)
			{
				VertexWeights = new float[NumVertices, NumWeightsPerVertex];
				for (var i = 0; i < NumVertices; i++)
				{
					for (var j = 0; j < NumWeightsPerVertex; j++)
					{
						VertexWeights[i, j] = reader.Read<float>();
					}
				}
				
			}
			StripLengths = new ushort[NumStrips];
			for (var i = 0; i < NumStrips; i++)
			{
				StripLengths[i] = reader.Read<ushort>();
			}
			
			HasFaces = reader.Read<byte>() != 0;
			
			if ((HasFaces)&&(NumStrips!=0))
			{
				Strips = new ushort[NumStrips][];
				for (var i = 0; i < NumStrips; i++)
				{
					var length = StripLengths[i];
					Strips[i] = new ushort[length];
					for (var j = 0; j < length; j++)
					{
						Strips[i][j] = reader.Read<ushort>();
					}
				}
				
			}
			if ((HasFaces)&&(NumStrips==0))
			{
				Triangles = new Triangle[NumTriangles];
				for (var i = 0; i < NumTriangles; i++)
				{
					var value = new Triangle();
					value.Deserialize(reader);
					Triangles[i] = value;
				}
				
			}
			HasBoneIndices = reader.Read<byte>() != 0;
			
			if (HasBoneIndices)
			{
				BoneIndices = new byte[NumVertices, NumWeightsPerVertex];
				for (var i = 0; i < NumVertices; i++)
				{
					for (var j = 0; j < NumWeightsPerVertex; j++)
					{
						BoneIndices[i, j] = reader.Read<byte>();
					}
				}
				
			}
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(NumVertices);
			
			writer.Write(NumTriangles);
			
			writer.Write(NumBones);
			
			writer.Write(NumStrips);
			
			writer.Write(NumWeightsPerVertex);
			
			for (var i = 0; i < NumBones; i++)
			{
				writer.Write(Bones[i]);
			}
			
			writer.Write((byte) (HasVertexMap ? 1 : 0));
			
			if (HasVertexMap)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(VertexMap[i]);
				}
				
			}
			writer.Write((byte) (HasVertexWeights ? 1 : 0));
			
			if (HasVertexWeights)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					for (var j = 0; j < NumWeightsPerVertex; j++)
					{
						writer.Write(VertexWeights[i, j]);
					}
				}
				
			}
			for (var i = 0; i < NumStrips; i++)
			{
				writer.Write(StripLengths[i]);
			}
			
			writer.Write((byte) (HasFaces ? 1 : 0));
			
			if ((HasFaces)&&(NumStrips!=0))
			{
				for (var i = 0; i < NumStrips; i++)
				{
					var length = StripLengths[i];
					for (var j = 0; j < length; j++)
					{
						writer.Write(Strips[i][j]);
					}
				}
				
			}
			if ((HasFaces)&&(NumStrips==0))
			{
				for (var i = 0; i < NumTriangles; i++)
				{
					writer.Write(Triangles[i]);
				}
				
			}
			writer.Write((byte) (HasBoneIndices ? 1 : 0));
			
			if (HasBoneIndices)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					for (var j = 0; j < NumWeightsPerVertex; j++)
					{
						writer.Write(BoneIndices[i, j]);
					}
				}
				
			}
		}
	}
	

}
