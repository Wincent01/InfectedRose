using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Grouping node for nodes in a Portal
	///         
	/// </summary>
	public class NiRoomGroup : NiNode
	{
		/// <summary>
		/// Outer Shell Geometry Node?
		/// </summary>
		public Ptr<NiNode> ShellLink { get; set; } 
		
		/// <summary>
		/// Number of rooms in this group
		/// </summary>
		public int NumRooms { get; set; } 
		
		/// <summary>
		/// Rooms associated with this group.
		/// </summary>
		public Ptr<NiRoom>[] Rooms { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			ShellLink = reader.Read<Ptr<NiNode>>();
			
			NumRooms = reader.Read<int>();
			
			Rooms = new Ptr<NiRoom>[NumRooms];
			for (var i = 0; i < NumRooms; i++)
			{
				Rooms[i] = reader.Read<Ptr<NiRoom>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(ShellLink);
			
			writer.Write(NumRooms);
			
			for (var i = 0; i < NumRooms; i++)
			{
				writer.Write(Rooms[i]);
			}
			
		}
	}
	

}
