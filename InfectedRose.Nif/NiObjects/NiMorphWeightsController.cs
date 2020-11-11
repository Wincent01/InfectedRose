using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiMorphWeightsController : NiInterpController
	{
		/// <summary>
		/// 
		/// </summary>
		public int Unknown2 { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public uint NumInterpolators { get; set; } 
		
		/// <summary>
		/// 
		/// </summary>
		public Ptr<NiObject>[] Interpolators { get; set; } 
		
		/// <summary>
		/// The number of morph targets.
		/// </summary>
		public uint NumTargets { get; set; } 
		
		/// <summary>
		/// Name of each morph target.
		/// </summary>
		public NiString[] TargetNames { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Unknown2 = reader.Read<int>();
			
			NumInterpolators = reader.Read<uint>();
			
			Interpolators = new Ptr<NiObject>[NumInterpolators];
			for (var i = 0; i < NumInterpolators; i++)
			{
				Interpolators[i] = reader.Read<Ptr<NiObject>>();
			}
			
			NumTargets = reader.Read<uint>();
			
			TargetNames = new NiString[NumTargets];
			for (var i = 0; i < NumTargets; i++)
			{
				var value = new NiString();
				value.Deserialize(reader);
				TargetNames[i] = value;
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Unknown2);
			
			writer.Write(NumInterpolators);
			
			for (var i = 0; i < NumInterpolators; i++)
			{
				writer.Write(Interpolators[i]);
			}
			
			writer.Write(NumTargets);
			
			for (var i = 0; i < NumTargets; i++)
			{
				writer.Write(TargetNames[i]);
			}
			
		}
	}
	

}
