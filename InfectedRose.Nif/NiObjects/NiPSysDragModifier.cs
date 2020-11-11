using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class NiPSysDragModifier : NiPSysModifier
	{
		/// <summary>
		/// Parent reference.
		/// </summary>
		public Ptr<NiObject> Parent { get; set; } 
		
		/// <summary>
		/// The drag axis.
		/// </summary>
		public Vector3 DragAxis { get; set; } 
		
		/// <summary>
		/// Drag percentage.
		/// </summary>
		public float Percentage { get; set; } 
		
		/// <summary>
		/// The range.
		/// </summary>
		public float Range { get; set; } 
		
		/// <summary>
		/// The range falloff.
		/// </summary>
		public float RangeFalloff { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Parent = reader.Read<Ptr<NiObject>>();
			
			DragAxis = new Vector3();
			DragAxis.Deserialize(reader);
			
			Percentage = reader.Read<float>();
			
			Range = reader.Read<float>();
			
			RangeFalloff = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Parent);
			
			writer.Write(DragAxis);
			
			writer.Write(Percentage);
			
			writer.Write(Range);
			
			writer.Write(RangeFalloff);
			
		}
	}
	

}
