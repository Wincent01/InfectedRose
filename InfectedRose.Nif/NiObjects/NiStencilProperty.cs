using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Allows control of stencil testing.
	///         
	/// </summary>
	public class NiStencilProperty : NiProperty
	{
		/// <summary>
		/// 
		///             Property flags:
		///             Bit 0: Stencil Enable
		///             Bits 1-3: Fail Action
		///             Bits 4-6: Z Fail Action
		///             Bits 7-9: Pass Action
		///             Bits 10-11: Draw Mode
		///             Bits 12-14: Stencil Function
		///         
		/// </summary>
		public ushort Flags { get; set; } 
		
		/// <summary>
		/// Unknown.  Default is 0.
		/// </summary>
		public uint StencilRef { get; set; } 
		
		/// <summary>
		/// A bit mask. The default is 0xffffffff.
		/// </summary>
		public uint StencilMask { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			Flags = reader.Read<ushort>();
			
			StencilRef = reader.Read<uint>();
			
			StencilMask = reader.Read<uint>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(Flags);
			
			writer.Write(StencilRef);
			
			writer.Write(StencilMask);
			
		}
	}
	

}
