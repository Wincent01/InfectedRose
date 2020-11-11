using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Base for all force field particle modifiers.
	///         
	/// </summary>
	public abstract class NiPSysFieldModifier : NiPSysModifier
	{
		/// <summary>
		/// Force Field Object
		/// </summary>
		public Ptr<NiAVObject> FieldObject { get; set; } 
		
		/// <summary>
		/// Magnitude of the force
		/// </summary>
		public float Magnitude { get; set; } 
		
		/// <summary>
		/// Controls how quick the field diminishes
		/// </summary>
		public float Attenuation { get; set; } 
		
		/// <summary>
		/// Use maximum distance
		/// </summary>
		public bool UseMaxDistance { get; set; } 
		
		/// <summary>
		/// Maximum distance
		/// </summary>
		public float MaxDistance { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			FieldObject = reader.Read<Ptr<NiAVObject>>();
			
			Magnitude = reader.Read<float>();
			
			Attenuation = reader.Read<float>();
			
			UseMaxDistance = reader.Read<byte>() != 0;
			
			MaxDistance = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(FieldObject);
			
			writer.Write(Magnitude);
			
			writer.Write(Attenuation);
			
			writer.Write((byte) (UseMaxDistance ? 1 : 0));
			
			writer.Write(MaxDistance);
			
		}
	}
	

}
