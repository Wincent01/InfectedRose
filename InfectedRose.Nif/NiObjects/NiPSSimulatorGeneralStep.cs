using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Encapsulates a floodgate kernel that updates particle size, colors, and rotations.
	///         
	/// </summary>
	public class NiPSSimulatorGeneralStep : NiPSSimulatorStep
	{
		/// <summary>
		/// The number of size animation keys.
		/// </summary>
		public byte NumSizeKeys { get; set; } 
		
		/// <summary>
		/// The particle size keys.
		/// </summary>
		public Key<NiConstruct<float>>[] SizeKeys { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown1 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public float Unknown3 { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumSizeKeys = reader.Read<byte>();
			
			SizeKeys = new Key<NiConstruct<float>>[NumSizeKeys];
			for (var i = 0; i < NumSizeKeys; i++)
			{
				var value = new Key<NiConstruct<float>>();
				value.Deserialize(reader);
				SizeKeys[i] = value;
			}
			
			Unknown1 = reader.Read<float>();
			
			Unknown2 = reader.Read<float>();
			
			Unknown3 = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumSizeKeys);
			
			for (var i = 0; i < NumSizeKeys; i++)
			{
				writer.Write(SizeKeys[i]);
			}
			
			writer.Write(Unknown1);
			
			writer.Write(Unknown2);
			
			writer.Write(Unknown3);
			
		}
	}
	

}
