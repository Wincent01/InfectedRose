using System.IO;
using System.Xml;
using InfectedRose.LXFML.BrickTypes;

namespace InfectedRose.LXFML.DataTypes
{
    public class Brick
    {
        public int designID { get; set; }
        public Part BrickPart { get; set; }
        public Bone BrickBone { get; set; }
        
        public Brick(string xmlData, int refID)
        {
            using TextReader tr = new StringReader(xmlData);
            XmlReader xml = XmlReader.Create(tr);
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    if (xml.HasAttributes)
                    {
                        switch (xml.Name)
                        {
                            case "Brick":
                                if (int.Parse(xml.GetAttribute("refID")) == refID)
                                {
                                    designID = int.Parse(xml.GetAttribute("designID"));
                                }
                                break;
                        }
                    }
                }
            }
            
            BrickBone = new Bone(refID, xmlData);
            BrickPart = new Part(refID, xmlData);
        }
    }
}