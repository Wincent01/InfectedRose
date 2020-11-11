using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Particle system data.
	///         
	/// </summary>
	public class NiPSysData : NiRotatingParticlesData
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public ParticleDesc[] ParticleDescriptions { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public bool HasUnknownFloats3 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public float[] UnknownFloats3 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public ushort UnknownShort2 { get; set; } 
		
		/// <summary>
		/// Boolean for Num Subtexture Offset UVs
		/// </summary>
		public bool HasSubtextureOffsetUVs { get; set; } 
		
		/// <summary>
		/// How many quads to use in BSPSysSubTexModifier for texture atlasing
		/// </summary>
		public uint NumSubtextureOffsetUVs { get; set; } 
		
		/// <summary>
		/// Sets aspect ratio for Subtexture Offset UV quads
		/// </summary>
		public float AspectRatio { get; set; } 
		
		/// <summary>
		/// Defines UV offsets
		/// </summary>
		public Vector4[] SubtextureOffsetUVs { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt4 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt5 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt6 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public ushort UnknownShort3 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte4 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ParticleDescriptions = new ParticleDesc[NumVertices];
			for (var i = 0; i < NumVertices; i++)
			{
				var value = new ParticleDesc();
				value.Deserialize(reader);
				ParticleDescriptions[i] = value;
			}
			
			HasUnknownFloats3 = reader.Read<byte>() != 0;
			
			if (HasUnknownFloats3)
			{
				UnknownFloats3 = new float[NumVertices];
				for (var i = 0; i < NumVertices; i++)
				{
					UnknownFloats3[i] = reader.Read<float>();
				}
				
			}
			UnknownShort1 = reader.Read<ushort>();
			
			UnknownShort2 = reader.Read<ushort>();
			
			HasSubtextureOffsetUVs = reader.Read<byte>() != 0;
			
			NumSubtextureOffsetUVs = reader.Read<uint>();
			
			AspectRatio = reader.Read<float>();
			
			if (HasSubtextureOffsetUVs)
			{
				SubtextureOffsetUVs = new Vector4[NumSubtextureOffsetUVs];
				for (var i = 0; i < NumSubtextureOffsetUVs; i++)
				{
					var value = new Vector4();
					value.Deserialize(reader);
					SubtextureOffsetUVs[i] = value;
				}
				
			}
			UnknownInt4 = reader.Read<uint>();
			
			UnknownInt5 = reader.Read<uint>();
			
			UnknownInt6 = reader.Read<uint>();
			
			UnknownShort3 = reader.Read<ushort>();
			
			UnknownByte4 = reader.Read<byte>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			for (var i = 0; i < NumVertices; i++)
			{
				writer.Write(ParticleDescriptions[i]);
			}
			
			writer.Write((byte) (HasUnknownFloats3 ? 1 : 0));
			
			if (HasUnknownFloats3)
			{
				for (var i = 0; i < NumVertices; i++)
				{
					writer.Write(UnknownFloats3[i]);
				}
				
			}
			writer.Write(UnknownShort1);
			
			writer.Write(UnknownShort2);
			
			writer.Write((byte) (HasSubtextureOffsetUVs ? 1 : 0));
			
			writer.Write(NumSubtextureOffsetUVs);
			
			writer.Write(AspectRatio);
			
			if (HasSubtextureOffsetUVs)
			{
				for (var i = 0; i < NumSubtextureOffsetUVs; i++)
				{
					writer.Write(SubtextureOffsetUVs[i]);
				}
				
			}
			writer.Write(UnknownInt4);
			
			writer.Write(UnknownInt5);
			
			writer.Write(UnknownInt6);
			
			writer.Write(UnknownShort3);
			
			writer.Write(UnknownByte4);
			
		}
	}
	

}
