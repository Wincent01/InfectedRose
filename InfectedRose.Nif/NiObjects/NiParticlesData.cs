using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Generic rotating particles data object.
	///         
	/// </summary>
	public class NiParticlesData : NiGeometryData
	{
		/// <summary>
		/// Is the particle size array present?
		/// </summary>
		public bool HasRadii { get; set; } 
		
		/// <summary>
		/// The individual particel sizes.
		/// </summary>
		public float[] Radii { get; set; } 
		
		/// <summary>
		/// The number of active particles at the time the system was saved. This is also the number of valid entries in the following arrays.
		/// </summary>
		public ushort NumActive { get; set; } 
		
		/// <summary>
		/// Is the particle size array present?
		/// </summary>
		public bool HasSizes { get; set; } 
		
		/// <summary>
		/// The individual particel sizes.
		/// </summary>
		public float[] Sizes { get; set; } 
		
		/// <summary>
		/// Is the particle rotation array present?
		/// </summary>
		public bool HasRotations { get; set; } 
		
		/// <summary>
		/// The individual particle rotations.
		/// </summary>
		public Quaternion[] Rotations { get; set; } 
		
		/// <summary>
		/// Unknown, probably a boolean.
		/// </summary>
		public byte UnknownByte1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiObject> UnknownLink { get; set; } 
		
		/// <summary>
		/// Are the angles of rotation present?
		/// </summary>
		public bool HasRotationAngles { get; set; } 
		
		/// <summary>
		/// Angles of rotation
		/// </summary>
		public float[] RotationAngles { get; set; } 
		
		/// <summary>
		/// Are axes of rotation present?
		/// </summary>
		public bool HasRotationAxes { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Vector3[] RotationAxes { get; set; } 
		
		/// <summary>
		/// if value is no, a single image rendered
		/// </summary>
		public bool HasUVQuadrants { get; set; } 
		
		/// <summary>
		/// 2,4,8,16,32,64 are potential values. If "Has" was no then this should be 256, which represents a 16x16 framed image, which is invalid
		/// </summary>
		public byte NumUVQuadrants { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Vector4[] UVQuadrants { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte2 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			HasRadii = reader.Read<byte>() != 0;
			
			if (HasRadii)
			{
				Radii = new float[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					Radii[i] = reader.Read<float>();
				}
				
			}
			NumActive = reader.Read<ushort>();
			
			HasSizes = reader.Read<byte>() != 0;
			
			if (HasSizes)
			{
				Sizes = new float[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					Sizes[i] = reader.Read<float>();
				}
				
			}
			HasRotations = reader.Read<byte>() != 0;
			
			if (HasRotations)
			{
				Rotations = new Quaternion[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Quaternion();
					value.Deserialize(reader);
					Rotations[i] = value;
				}
				
			}
			UnknownByte1 = reader.Read<byte>();
			
			UnknownLink = reader.Read<Ptr<NiObject>>();
			
			HasRotationAngles = reader.Read<byte>() != 0;
			
			if (HasRotationAngles)
			{
				RotationAngles = new float[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					RotationAngles[i] = reader.Read<float>();
				}
				
			}
			HasRotationAxes = reader.Read<byte>() != 0;
			
			if (HasRotationAxes)
			{
				RotationAxes = new Vector3[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					var value = new Vector3();
					value.Deserialize(reader);
					RotationAxes[i] = value;
				}
				
			}
			HasUVQuadrants = reader.Read<byte>() != 0;
			
			NumUVQuadrants = reader.Read<byte>();
			
			if (HasUVQuadrants)
			{
				UVQuadrants = new Vector4[NumUVQuadrants];
				for (var i = 0; i < NumUVQuadrants; i++)
				{
					var value = new Vector4();
					value.Deserialize(reader);
					UVQuadrants[i] = value;
				}
				
			}
			UnknownByte2 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write((byte) (HasRadii ? 1 : 0));
			
			if (HasRadii)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Radii[i]);
				}
				
			}
			writer.Write(NumActive);
			
			writer.Write((byte) (HasSizes ? 1 : 0));
			
			if (HasSizes)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Sizes[i]);
				}
				
			}
			writer.Write((byte) (HasRotations ? 1 : 0));
			
			if (HasRotations)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(Rotations[i]);
				}
				
			}
			writer.Write(UnknownByte1);
			
			writer.Write(UnknownLink);
			
			writer.Write((byte) (HasRotationAngles ? 1 : 0));
			
			if (HasRotationAngles)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(RotationAngles[i]);
				}
				
			}
			writer.Write((byte) (HasRotationAxes ? 1 : 0));
			
			if (HasRotationAxes)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(RotationAxes[i]);
				}
				
			}
			writer.Write((byte) (HasUVQuadrants ? 1 : 0));
			
			writer.Write(NumUVQuadrants);
			
			if (HasUVQuadrants)
			{
				for (var i = 0; i < NumUVQuadrants; i++)
				{
					writer.Write(UVQuadrants[i]);
				}
				
			}
			writer.Write(UnknownByte2);
			
		}
	}
	

}
