using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Unknown.
	///         
	/// </summary>
	public class FxRadioButton : FxWidget
	{
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt1 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt2 { get; set; } 
		
		/// <summary>
		/// Unknown.
		/// </summary>
		public uint UnknownInt3 { get; set; } 
		
		/// <summary>
		/// Number of unknown links.
		/// </summary>
		public uint NumButtons { get; set; } 
		
		/// <summary>
		/// Unknown pointers to other buttons.  Maybe other buttons in a group so they can be switch off if this one is switched on?
		/// </summary>
		public Ptr<FxRadioButton>[] Buttons { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UnknownInt1 = reader.Read<uint>();
			
			UnknownInt2 = reader.Read<uint>();
			
			UnknownInt3 = reader.Read<uint>();
			
			NumButtons = reader.Read<uint>();
			
			Buttons = new Ptr<FxRadioButton>[NumButtons];
			for (var i = 0; i < NumButtons; i++)
			{
				Buttons[i] = reader.Read<Ptr<FxRadioButton>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UnknownInt1);
			
			writer.Write(UnknownInt2);
			
			writer.Write(UnknownInt3);
			
			writer.Write(NumButtons);
			
			for (var i = 0; i < NumButtons; i++)
			{
				writer.Write(Buttons[i]);
			}
			
		}
	}
	

}
