using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	///         particle array entry
	///         
	/// </summary>
	public struct Particle : IConstruct
	{
		/// <summary>
		/// Particle velocity
		/// </summary>
		public Vector3 Velocity { get; set; } 
		
		/// <summary>
		/// Unknown
		/// </summary>
		public Vector3 UnknownVector { get; set; } 
		
		/// <summary>
		/// The particle's age.
		/// </summary>
		public float Lifetime { get; set; } 
		
		/// <summary>
		/// Maximum age of the particle.
		/// </summary>
		public float Lifespan { get; set; } 
		
		/// <summary>
		/// Timestamp of the last update.
		/// </summary>
		public float Timestamp { get; set; } 
		
		/// <summary>
		/// Unknown short
		/// </summary>
		public ushort UnknownShort { get; set; } 
		
		/// <summary>
		/// Particle/vertex index matches array index
		/// </summary>
		public ushort VertexID { get; set; } 
		
		public void Deserialize(BitReader reader)
		{
			Velocity = new Vector3();
			Velocity.Deserialize(reader);
			
			UnknownVector = new Vector3();
			UnknownVector.Deserialize(reader);
			
			Lifetime = reader.Read<float>();
			
			Lifespan = reader.Read<float>();
			
			Timestamp = reader.Read<float>();
			
			UnknownShort = reader.Read<ushort>();
			
			VertexID = reader.Read<ushort>();
			
		}
	
		public void Serialize(BitWriter writer)
		{
			writer.Write(Velocity);
			
			writer.Write(UnknownVector);
			
			writer.Write(Lifetime);
			
			writer.Write(Lifespan);
			
			writer.Write(Timestamp);
			
			writer.Write(UnknownShort);
			
			writer.Write(VertexID);
			
		}
	}
	

}
