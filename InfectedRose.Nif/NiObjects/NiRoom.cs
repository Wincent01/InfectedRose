using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         Grouping node for nodes in a Portal
	///         
	/// </summary>
	public class NiRoom : NiNode
	{
		/// <summary>
		/// Number of walls in a room?
		/// </summary>
		public int NumWalls { get; set; } 
		
		/// <summary>
		/// Face normal and unknown value.
		/// </summary>
		public Vector4[] WallPlane { get; set; } 
		
		/// <summary>
		/// Number of doors into room
		/// </summary>
		public int NumInPortals { get; set; } 
		
		/// <summary>
		/// Number of portals into room
		/// </summary>
		public Ptr<NiPortal>[] InPortals { get; set; } 
		
		/// <summary>
		/// Number of doors out of room
		/// </summary>
		public int NumPortals2 { get; set; } 
		
		/// <summary>
		/// Number of portals out of room
		/// </summary>
		public Ptr<NiPortal>[] Portals2 { get; set; } 
		
		/// <summary>
		/// Number of unknowns
		/// </summary>
		public int NumItems { get; set; } 
		
		/// <summary>
		/// All geometry associated with room.
		/// </summary>
		public Ptr<NiAVObject>[] Items { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			NumWalls = reader.Read<int>();
			
			WallPlane = new Vector4[NumWalls];
			for (var i = 0; i < NumWalls; i++)
			{
				var value = new Vector4();
				value.Deserialize(reader);
				WallPlane[i] = value;
			}
			
			NumInPortals = reader.Read<int>();
			
			InPortals = new Ptr<NiPortal>[NumInPortals];
			for (var i = 0; i < NumInPortals; i++)
			{
				InPortals[i] = reader.Read<Ptr<NiPortal>>();
			}
			
			NumPortals2 = reader.Read<int>();
			
			Portals2 = new Ptr<NiPortal>[NumPortals2];
			for (var i = 0; i < NumPortals2; i++)
			{
				Portals2[i] = reader.Read<Ptr<NiPortal>>();
			}
			
			NumItems = reader.Read<int>();
			
			Items = new Ptr<NiAVObject>[NumItems];
			for (var i = 0; i < NumItems; i++)
			{
				Items[i] = reader.Read<Ptr<NiAVObject>>();
			}
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(NumWalls);
			
			for (var i = 0; i < NumWalls; i++)
			{
				writer.Write(WallPlane[i]);
			}
			
			writer.Write(NumInPortals);
			
			for (var i = 0; i < NumInPortals; i++)
			{
				writer.Write(InPortals[i]);
			}
			
			writer.Write(NumPortals2);
			
			for (var i = 0; i < NumPortals2; i++)
			{
				writer.Write(Portals2[i]);
			}
			
			writer.Write(NumItems);
			
			for (var i = 0; i < NumItems; i++)
			{
				writer.Write(Items[i]);
			}
			
		}
	}
	

}
