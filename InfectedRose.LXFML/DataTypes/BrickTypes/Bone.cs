using System.IO;
using System.Xml;

namespace InfectedRose.LXFML.BrickTypes
{
    public class Bone
    {
        public Transform TransformData { get; set; } = new Transform();
        
        public Bone(int refID, string xmlData)
        {
            using TextReader tr = new StringReader(xmlData);
            XmlReader xml = XmlReader.Create(tr);
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    if (xml.HasAttributes)
                    {
                        if (xml.Name == "Bone" && int.Parse(xml.GetAttribute("refID")) == refID)
                        {
                            TransformData.ParseTransform(xml.GetAttribute("transformation"));
                        }
                    }
                }
            }
        }
    }
}