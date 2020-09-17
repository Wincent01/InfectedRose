using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using InfectedRose.LXFML.DataTypes;

namespace InfectedRose.LXFML.LXFMLTypes
{
    public class LXFML5
    {
        private string data { get; set; }
        private int BrickCount { get; set; } = 0;
        private List<Brick> Bricks { get; set; } = new List<Brick>();
        public string Application {get; set;}
        public string AppVersionMajor { get; set; }
        public string AppVersionMinor { get; set; }
        public string Brand { get; set; }
        public string BrickSet { get; set; }
        public string Brick { get; set; }

        public LXFML5(string inboundData)
        {
            data = inboundData;
        }

        public void ParseXML() // Read the XML metadata
        {
            using (TextReader tr = new StringReader(data))
            {
                XmlReader xml = XmlReader.Create(tr);
                while (xml.Read())
                {
                    if (xml.NodeType == XmlNodeType.Element)
                    {
                        if (xml.HasAttributes)
                        {
                            switch (xml.Name)
                            {
                                case "Application":
                                    Application = xml.GetAttribute("name");
                                    AppVersionMajor = xml.GetAttribute("versionMajor");
                                    AppVersionMinor = xml.GetAttribute("versionMinor");
                                    break;
                                case "Brand":
                                    Brand = xml.GetAttribute("name");
                                    break;
                                case "BrickSet":
                                    BrickSet = xml.GetAttribute("version");
                                    break;
                                case "Brick":
                                    if (int.Parse(xml.GetAttribute("refID")) > BrickCount)
                                    {
                                        BrickCount = int.Parse(xml.GetAttribute("refID"));
                                    }
                                    break;
                            }
                        }
                    }
                }
                while (BrickCount != 0)
                {
                    Bricks.Add(new Brick(data, BrickCount));
                    BrickCount = BrickCount - 1;
                }
            }
        }
    }
}