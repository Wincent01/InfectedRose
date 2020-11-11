using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Mesh data: vertices, vertex normals, etc.
	///         
	/// </summary>
	public abstract class NiGeometryData : NiObject
	{
		/// <summary>
		/// Unknown identifier. Always 0.
		/// </summary>
		public int UnknownInt { get; set; }

		/// <summary>
		/// Number of vertices.
		/// </summary>
		public ushort NumVertices { get; set; } 
		
		/// <summary>
		/// Used with NiCollision objects when OBB or TRI is set.
		/// </summary>
		public byte KeepFlags { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public byte CompressFlags { get; set; } 
		
		/// <summary>
		/// Is the vertex array present? (Always non-zero.)
		/// </summary>
		public bool HasVertices { get; set; } 
		
		/// <summary>
		/// The mesh vertices.
		/// </summary>
		public Vector3[] Vertices { get; set; } 
		
		/// <summary>
		/// Flag for tangents and bitangents in upper byte. Texture flags in lower byte.
		/// </summary>
		public ushort NumUVSets { get; set; } 
		
		/// <summary>
		/// Do we have lighting normals? These are essential for proper lighting: if not present, the model will only be influenced by ambient light.
		/// </summary>
		public bool HasNormals { get; set; } 
		
		/// <summary>
		/// The lighting normals.
		/// </summary>
		public Vector3[] Normals { get; set; } 
		
		/// <summary>
		/// Tangent vectors.
		/// </summary>
		public Vector3[] Tangents { get; set; } 
		
		/// <summary>
		/// Bitangent vectors.
		/// </summary>
		public Vector3[] Bitangents { get; set; } 
		
		/// <summary>
		/// Center of the bounding box (smallest box that contains all vertices) of the mesh.
		/// </summary>
		public Vector3 Center { get; set; } 
		
		/// <summary>
		/// Radius of the mesh: maximal Euclidean distance between the center and all vertices.
		/// </summary>
		public float Radius { get; set; } 
		
		/// <summary>
		/// Unknown, always 0?
		/// </summary>
		public short[] Unknown13shorts { get; set; } 
		
		/// <summary>
		/// 
		///             Do we have vertex colors? These are usually used to fine-tune the lighting of the model.
		/// 
		///             Note: how vertex colors influence the model can be controlled by having a NiVertexColorProperty object as a property child of the root node. If this property object is not present, the vertex colors fine-tune lighting.
		/// 
		///             Note 2: set to either 0 or 0xFFFFFFFF for NifTexture compatibility.
		///         
		/// </summary>
		public bool HasVertexColors { get; set; } 
		
		/// <summary>
		/// The vertex colors.
		/// </summary>
		public Color4[] VertexColors { get; set; } 
		
		/// <summary>
		/// The UV texture coordinates. They follow the OpenGL standard: some programs may require you to flip the second coordinate.
		/// </summary>
		public TexCoord[,] UVSets { get; set; } 
		
		/// <summary>
		/// Consistency Flags
		/// </summary>
		public ConsistencyType ConsistencyFlags { get; set; }

		/// <summary>
		/// Unknown.
		/// </summary>
		public Ptr<AbstractAdditionalGeometryData> AdditionalData { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt = reader.Read<int>();

			NumVertices = reader.Read<ushort>();
			
			KeepFlags = reader.Read<byte>();
			
			CompressFlags = reader.Read<byte>();
			
			HasVertices = reader.Read<byte>() != 0;
			
			if (HasVertices)
			{
				Vertices = new Vector3[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Vector3();
					value.Deserialize(reader);
					Vertices[i] = value;
				}
				
			}
			NumUVSets = reader.Read<ushort>();
			
			HasNormals = reader.Read<byte>() != 0;
			
			if (HasNormals)
			{
				Normals = new Vector3[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Vector3();
					value.Deserialize(reader);
					Normals[i] = value;
				}
				
			}
			if ((HasNormals)&&((NumUVSets&61440) != 0))
			{
				Tangents = new Vector3[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Vector3();
					value.Deserialize(reader);
					Tangents[i] = value;
				}
				
			}
			if ((HasNormals)&&((NumUVSets&61440) != 0))
			{
				Bitangents = new Vector3[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Vector3();
					value.Deserialize(reader);
					Bitangents[i] = value;
				}
				
			}
			Center = new Vector3();
			Center.Deserialize(reader);
			
			Radius = reader.Read<float>();
			
			/*
			Unknown13shorts = new short[13];
			for (var i = 0; i < 13; i++)
			{
				Unknown13shorts[i] = reader.Read<short>();
			}
			*/
			
			HasVertexColors = reader.Read<byte>() != 0;
			
			if (HasVertexColors)
			{
				VertexColors = new Color4[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Color4();
					value.Deserialize(reader);
					VertexColors[i] = value;
				}
				
			}
			UVSets = new TexCoord[(NumUVSets&63), NumVertices];
			for (var i = 0; i < (NumUVSets&63); i++)
			{
				for (var j = 0; j < NumVertices; j++)
				{
					var value = new TexCoord();
					value.Deserialize(reader);
					UVSets[i, j] = value;
				}
			}
			
			ConsistencyFlags = (ConsistencyType) reader.Read<ushort>();
			
			AdditionalData = reader.Read<Ptr<AbstractAdditionalGeometryData>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt);

			writer.Write(NumVertices);
			
			writer.Write(KeepFlags);
			
			writer.Write(CompressFlags);
			
			writer.Write((byte) (HasVertices ? 1 : 0));
			
			if (HasVertices)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Vertices[i]);
				}
				
			}
			writer.Write(NumUVSets);
			
			writer.Write((byte) (HasNormals ? 1 : 0));
			
			if (HasNormals)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Normals[i]);
				}
				
			}
			if ((HasNormals)&&((NumUVSets&61440) != 0))
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Tangents[i]);
				}
				
			}
			if ((HasNormals)&&((NumUVSets&61440) != 0))
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Bitangents[i]);
				}
				
			}
			writer.Write(Center);
			
			writer.Write(Radius);
			
			/*
			for (var i = 0; i < 13; i++)
			{
				writer.Write(Unknown13shorts[i]);
			}
			*/
			
			writer.Write((byte) (HasVertexColors ? 1 : 0));
			
			if (HasVertexColors)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(VertexColors[i]);
				}
				
			}
			for (var i = 0; i < (NumUVSets&63); i++)
			{
				for (var j = 0; j < NumVertices; j++)
				{
					writer.Write(UVSets[i, j]);
				}
			}
			
			writer.Write((ushort) ConsistencyFlags);
			
			writer.Write(AdditionalData);
			
		}
	}
	

}
