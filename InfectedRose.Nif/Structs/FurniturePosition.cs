using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Describes a furniture position?
	///         
	/// </summary>
	public class FurniturePosition : IConstruct
	{
		/// <summary>
		/// Offset of furniture marker.
		/// </summary>
		public Vector3 Offset { get; set; } 
		
		/// <summary>
		/// Furniture marker orientation.
		/// </summary>
		public ushort Orientation { get; set; } 
		
		/// <summary>
		/// Refers to a furnituremarkerxx.nif file. Always seems to be the same as Position Ref 2.
		/// </summary>
		public byte PositionRef1 { get; set; } 
		
		/// <summary>
		/// Refers to a furnituremarkerxx.nif file. Always seems to be the same as Position Ref 1.
		/// </summary>
		public byte PositionRef2 { get; set; } 
		
		/// <summary>
		/// Similar to Orientation, in float form.
		/// </summary>
		public float Heading { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public AnimationType AnimationType { get; set; } 
		
		/// <summary>
		/// Unknown/unused in nif?
		/// </summary>
		public ushort EntryProperties { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Offset = new Vector3();
			Offset.Deserialize(reader);
			
			Orientation = reader.Read<ushort>();
			
			PositionRef1 = reader.Read<byte>();
			
			PositionRef2 = reader.Read<byte>();
			
			Heading = reader.Read<float>();
			
			AnimationType = (AnimationType) reader.Read<ushort>();

			EntryProperties = reader.Read<ushort>();

		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Offset);
			
			writer.Write(Orientation);
			
			writer.Write(PositionRef1);
			
			writer.Write(PositionRef2);
			
			writer.Write(Heading);
			
			writer.Write((ushort) AnimationType);
			
			writer.Write(EntryProperties);
			
		}
	}
	

}
