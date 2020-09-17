using System.IO;
using System.Xml;

namespace InfectedRose.LXFML.BrickTypes
{
    public class Material
    {
        public int MatID { get; set; }
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public int Alpha { get; set; }
        public string MaterialType { get; set; }

        public Material(int ID)
        {
            return;
        }
    }
}