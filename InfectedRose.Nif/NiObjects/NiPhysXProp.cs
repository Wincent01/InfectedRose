using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown PhysX node.
	///         
	/// </summary>
	public class NiPhysXProp : NiObjectNET
	{
		/// <summary>
		/// Unknown
		/// </summary>
		public float UnknownFloat1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiObject>[] UnknownRefs1 { get; set; } 
		
		/// <summary>
		/// Number of NiPhysXTransformDest references
		/// </summary>
		public int NumDests { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Ptr<NiPhysXTransformDest>[] TransformDests { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public byte UnknownByte { get; set; } 
		
		/// <summary>
		/// PhysX Property Description.
		/// </summary>
		public Ptr<NiPhysXPropDesc> PropDescription { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownFloat1 = reader.Read<float>();
			
			UnknownInt1 = reader.Read<uint>();
			
			UnknownRefs1 = new Ptr<NiObject>[UnknownInt1];
			for (var i = 0; i < UnknownInt1; i++)
			{
				UnknownRefs1[i] = reader.Read<Ptr<NiObject>>();
			}
			
			NumDests = reader.Read<int>();
			
			TransformDests = new Ptr<NiPhysXTransformDest>[NumDests];
			for (var i = 0; i < NumDests; i++)
			{
				TransformDests[i] = reader.Read<Ptr<NiPhysXTransformDest>>();
			}
			
			UnknownByte = reader.Read<byte>();
			
			PropDescription = reader.Read<Ptr<NiPhysXPropDesc>>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownFloat1);
			
			writer.Write(UnknownInt1);
			
			for (var i = 0; i < UnknownInt1; i++)
			{
				writer.Write(UnknownRefs1[i]);
			}
			
			writer.Write(NumDests);
			
			for (var i = 0; i < NumDests; i++)
			{
				writer.Write(TransformDests[i]);
			}
			
			writer.Write(UnknownByte);
			
			writer.Write(PropDescription);
			
		}
	}
	

}
