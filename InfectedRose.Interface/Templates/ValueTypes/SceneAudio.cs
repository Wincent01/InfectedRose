using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes;

[XmlRoot("SceneAudioAttributes")]
public class SceneAudio
{
    [JsonPropertyName("music-cue")]
    [XmlAttribute("musicCue")]
    public string MusicCue { get; set; }
        
    [JsonPropertyName("music-param-name")]
    [XmlAttribute("musicParamName")]
    public string MusicParamName { get; set; }
        
    [JsonPropertyName("guid-2d")]
    [XmlAttribute("guid2D")]
    public string Guid2D { get; set; }
        
    [JsonPropertyName("guid-3d")]
    [XmlAttribute("guid3D")]
    public string Guid3D { get; set; }
        
    [JsonPropertyName("group-name")]
    [XmlAttribute("groupName")]
    public string GroupName { get; set; }
        
    [JsonPropertyName("program-name")]
    [XmlAttribute("programName")]
    public string ProgramName { get; set; }
        
    [JsonPropertyName("music-param-value")]
    [XmlAttribute("musicParamValue")]
    public string MusicParamValue { get; set; }
        
    [JsonPropertyName("boredom-time")]
    [XmlAttribute("boredomTime")]
    public string BoredomTime { get; set; }
}