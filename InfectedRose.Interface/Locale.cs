using System.Collections.Generic;
using System.Xml.Serialization;

namespace InfectedRose.Interface;

[XmlRoot("locales")]
public class Locales
{
    [XmlAttribute("count")]
    public int Count { get; set; }
        
    [XmlElement("locale")]
    public string[] Locale { get; set; }
}

[XmlRoot("translation")]
public class Translation
{
    [XmlAttribute("locale")]
    public string Locale { get; set; }
        
    [XmlText]
    public string Text { get; set; }
}

[XmlRoot("phrase")]
public class Phrase
{
    [XmlAttribute("id")]
    public string Id { get; set; }
        
    [XmlElement("translation")]
    public List<Translation> Translations { get; set; }
}

[XmlRoot("phrases")]
public class Phrases
{
    [XmlAttribute("count")]
    public int Count { get; set; }
        
    [XmlElement("phrase")]
    public List<Phrase> Phrase { get; set; }
}
    
[XmlRoot("localization")]
public class Localization
{
    [XmlAttribute("version")]
    public float Version { get; set; } = 1.200000f;
        
    [XmlElement("locales")]
    public Locales Locales { get; set; }
        
    [XmlElement("phrases")]
    public Phrases Phrases { get; set; }
}