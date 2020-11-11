using InfectedRose.Core;
using RakDotNet.IO;

namespace InfectedRose.Nif
{
	/// <summary>
	/// 
	/// </summary>
	public class NiImage : NiObject
	{
		/// <summary>
		/// 0 if the texture is internal to the NIF file.
		/// </summary>
		public byte UseExternal { get; set; } 
		
		/// <summary>
		/// The filepath to the texture.
		/// </summary>
		public FilePath FileName { get; set; } 
		
		/// <summary>
		/// Link to the internally stored image data.
		/// </summary>
		public Ptr<NiRawImageData> ImageData { get; set; } 
		
		/// <summary>
		/// Unknown.  Often seems to be 7. Perhaps m_uiMipLevels?
		/// </summary>
		public uint UnknownInt { get; set; } 
		
		/// <summary>
		/// Unknown.  Perhaps fImageScale?
		/// </summary>
		public float UnknownFloat { get; set; } 
		
		public override void Deserialize(BitReader reader)
		{
			base.Deserialize(reader);
			UseExternal = reader.Read<byte>();
			
			if (UseExternal!=0)
			{
				FileName = new FilePath();
				FileName.Deserialize(reader);
				
			}
			if (UseExternal==0)
			{
				ImageData = reader.Read<Ptr<NiRawImageData>>();
				
			}
			UnknownInt = reader.Read<uint>();
			
			UnknownFloat = reader.Read<float>();
			
		}
	
		public override void Serialize(BitWriter writer)
		{
			base.Serialize(writer);
			writer.Write(UseExternal);
			
			if (UseExternal!=0)
			{
				writer.Write(FileName);
				
			}
			if (UseExternal==0)
			{
				writer.Write(ImageData);
				
			}
			writer.Write(UnknownInt);
			
			writer.Write(UnknownFloat);
			
		}
	}
	

}
