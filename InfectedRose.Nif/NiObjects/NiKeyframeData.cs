using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Keyframes for mesh animation.
	///         
	/// </summary>
	public class NiKeyframeData : NiObject
	{
		/// <summary>
		/// The number of quaternion rotation keys. If the rotation type is XYZ (type 4) then this *must* be set to 1, and in this case the actual number of keys is stored in the XYZ Rotations field.
		/// </summary>
		public uint NumRotationKeys { get; set; } 
		
		/// <summary>
		/// The type of interpolation to use for rotation.  Can also be 4 to indicate that separate X, Y, and Z values are used for the rotation instead of Quaternions.
		/// </summary>
		public KeyType RotationType { get; set; } 
		
		/// <summary>
		/// The rotation keys if Quaternion rotation is used.
		/// </summary>
		public QuatKey<Quaternion>[] QuaternionKeys { get; set; } 
		
		/// <summary>
		/// Individual arrays of keys for rotating X, Y, and Z individually.
		/// </summary>
		public KeyGroup<float>[] XYZRotations { get; set; } 
		
		/// <summary>
		/// Translation keys.
		/// </summary>
		public KeyGroup<Vector3> Translations { get; set; } 
		
		/// <summary>
		/// Scale keys.
		/// </summary>
		public KeyGroup<float> Scales { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumRotationKeys = reader.Read<uint>();
			
			if (NumRotationKeys!=0)
			{
				RotationType = (KeyType) reader.Read<uint>();
				
			}
			if (RotationType!=(KeyType) 4)
			{
				QuaternionKeys = new QuatKey<Quaternion>[NumRotationKeys];
				for (var i = 0; i < NumRotationKeys; i++)
				{
					var value = new QuatKey<Quaternion>();
					value.Deserialize(reader);
					QuaternionKeys[i] = value;
				}
				
			}
			if (RotationType==(KeyType) 4)
			{
				XYZRotations = new KeyGroup<float>[3];
				for (var i = 0; i < 3; i++)
				{
					var value = new KeyGroup<float>();
					value.Deserialize(reader);
					XYZRotations[i] = value;
				}
				
			}
			Translations = new KeyGroup<Vector3>();
			Translations.Deserialize(reader);
			
			Scales = new KeyGroup<float>();
			Scales.Deserialize(reader);
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumRotationKeys);
			
			if (NumRotationKeys!=0)
			{
				writer.Write((uint) RotationType);
				
			}
			if (RotationType!=(KeyType) 4)
			{
				for (var i = 0; i < NumRotationKeys; i++)
				{
					writer.Write(QuaternionKeys[i]);
				}
				
			}
			if (RotationType==(KeyType) 4)
			{
				for (var i = 0; i < 3; i++)
				{
					writer.Write(XYZRotations[i]);
				}
				
			}
			writer.Write(Translations);
			
			writer.Write(Scales);
			
		}
	}
	

}
