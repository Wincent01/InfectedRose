using System.Linq;
using System.Xml.Serialization;

namespace InfectedRose.Builder.Behaviors.External
{
    [XmlRoot("Behavior")]
    public class BehaviorXml
    {
        [XmlAttribute] public uint Type { get; set; }
        
        [XmlElement] public uint Effect { get; set; }

        [XmlElement("Parameter")] public ParameterXml[] Parameters { get; set; } = new ParameterXml[0];

        public void SetParameter(string name, float value)
        {
            var list = Parameters.ToList();
            
            list.Add(new ParameterXml
            {
                Name = name,
                Value = value
            });
            
            Parameters = list.ToArray();
        }
        
        public void SetParameter(string name, BehaviorBase value)
        {
            var list = Parameters.ToList();
            
            list.Add(new ParameterXml
            {
                Name = name,
                Next = XmlExporter.ExportBehavior(value),
                Behavior = true
            });

            Parameters = list.ToArray();
        }
    }
}