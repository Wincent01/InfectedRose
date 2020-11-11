using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         In a .kf file, this links to a controllable object, via its name (or for version 10.2.0.0 and up, a link and offset to a NiStringPalette that contains the name), and a sequence of interpolators that apply to this controllable object, via links.
	///         
	/// </summary>
	public struct ControllerLink : IConstruct
	{
		/// <summary>
		/// Link to an interpolator.
		/// </summary>
		public Ptr<NiInterpolator> Interpolator { get; set; } 
		
		/// <summary>
		/// Unknown link. Usually -1.
		/// </summary>
		public Ptr<NiTimeController> Controller { get; set; } 
		
		/// <summary>
		/// Idle animations tend to have low values for this, and NIF objects that have high values tend to correspond with the important parts of the animation.
		/// </summary>
		public byte Priority { get; set; } 
		
		/// <summary>
		/// The name of the animated node.
		/// </summary>
		public NiString NodeName { get; set; } 
		
		/// <summary>
		/// Name of the property (NiMaterialProperty, ...), if this controller controls a property.
		/// </summary>
		public NiString PropertyType { get; set; } 
		
		/// <summary>
		/// Probably the object type name of the controller in the NIF file that is child of the controlled object.
		/// </summary>
		public NiString ControllerType { get; set; } 
		
		/// <summary>
		/// Some variable string (such as 'SELF_ILLUM', '0-0-TT_TRANSLATE_U', 'tongue_out', etc.).
		/// </summary>
		public NiString Variable1 { get; set; } 
		
		/// <summary>
		/// Another variable string, apparently used for particle system controllers.
		/// </summary>
		public NiString Variable2 { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Interpolator = reader.Read<Ptr<NiInterpolator>>();
			
			Controller = reader.Read<Ptr<NiTimeController>>();
			
			Priority = reader.Read<byte>();
			
			NodeName = new NiString();
			NodeName.Deserialize(reader);
			
			PropertyType = new NiString();
			PropertyType.Deserialize(reader);
			
			ControllerType = new NiString();
			ControllerType.Deserialize(reader);
			
			Variable1 = new NiString();
			Variable1.Deserialize(reader);
			
			Variable2 = new NiString();
			Variable2.Deserialize(reader);
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Interpolator);
			
			writer.Write(Controller);
			
			writer.Write(Priority);
			
			writer.Write(NodeName);
			
			writer.Write(PropertyType);
			
			writer.Write(ControllerType);
			
			writer.Write(Variable1);
			
			writer.Write(Variable2);
			
		}
	}
	

}
