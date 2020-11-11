using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Base class for mesh modifiers.
	///         
	/// </summary>
	public class NiMeshModifier : NiObject
	{
		/// <summary>
		/// The number of submit points used by this mesh modifier.
		/// </summary>
		public uint NumSubmitPoints { get; set; } 
		
		/// <summary>
		/// The submit points used by this mesh modifier
		/// </summary>
		public SyncPoint[] SubmitPoints { get; set; } 
		
		/// <summary>
		/// The number of complete points used by this mesh modifier.
		/// </summary>
		public uint NumCompletePoints { get; set; } 
		
		/// <summary>
		/// The complete points used by this mesh modifier
		/// </summary>
		public SyncPoint[] CompletePoints { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumSubmitPoints = reader.Read<uint>();
			
			SubmitPoints = new SyncPoint[NumSubmitPoints];
			for (var i = 0; i < NumSubmitPoints; i++)
			{
				SubmitPoints[i] = (SyncPoint) reader.Read<ushort>();
			}
			
			NumCompletePoints = reader.Read<uint>();
			
			CompletePoints = new SyncPoint[NumCompletePoints];
			for (var i = 0; i < NumCompletePoints; i++)
			{
				CompletePoints[i] = (SyncPoint) reader.Read<ushort>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumSubmitPoints);
			
			for (var i = 0; i < NumSubmitPoints; i++)
			{
				writer.Write((ushort) SubmitPoints[i]);
			}
			
			writer.Write(NumCompletePoints);
			
			for (var i = 0; i < NumCompletePoints; i++)
			{
				writer.Write((ushort) CompletePoints[i]);
			}
			
		}
	}
	

}
