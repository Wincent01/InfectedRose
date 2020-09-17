using System;
using System.IO;
using System.Xml;
using InfectedRose.LXFML.LXFMLTypes;

namespace InfectedRose.LXFML.DataTypes
{
    public class LXFML
    {
        public int LXFMLVersion { get; set; }
        private LXFML5 Lxfml5 { get; set; }
        
        public LXFML(string data) // Create the construct
        {
            using TextReader tr = new StringReader(data);
            XmlReader xml = XmlReader.Create(tr);
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    if (xml.Name == "LXFML" && xml.HasAttributes)
                    {
                        switch (xml.GetAttribute("versionMajor"))
                        {
                            case "5":
                                LXFMLVersion = 5;
                                Lxfml5 = new LXFML5(data);
                                Lxfml5.ParseXML();
                                break;
                        }
                    }
                }
            }
        }
    }
}