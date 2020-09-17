using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace InfectedRose.LXFML.BrickTypes
{
    public class Part
    {
        public List<Material> Materials { get; set; } = new List<Material>();
        public string decoration { get; set; }

        public Part(int refID, string xmlData)
        {
            using TextReader tr = new StringReader(xmlData);
            XmlReader xml = XmlReader.Create(tr);
            while (xml.Read())
            {
                if (xml.NodeType == XmlNodeType.Element)
                {
                    if (xml.HasAttributes)
                    {
                        if (xml.Name == "Part" && int.Parse(xml.GetAttribute("refID")) == refID)
                        {
                            string[] Mats = xml.GetAttribute("materials").Split(",");

                            decoration = xml.GetAttribute("decoration");
                            
                            if (Mats[0] != "0")
                            {
                                Materials.Add(new Material(int.Parse(Mats[0])));
                            }

                            if (Mats.Length > 1)
                            {
                                if (Mats[1] != "0")
                                {
                                    Materials.Add(new Material(int.Parse(Mats[1])));
                                }
                            }

                            if (Mats.Length > 2)
                            {
                                if (Mats[2] != "0")
                                {
                                    Materials.Add(new Material(int.Parse(Mats[2])));
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}