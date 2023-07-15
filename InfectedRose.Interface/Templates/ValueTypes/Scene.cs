using System.Text.Json.Serialization;
using InfectedRose.Triggers;

namespace InfectedRose.Interface.Templates.ValueTypes;

public class Scene
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
        
    [JsonPropertyName("layer")]
    public int Layer { get; set; }
        
    [JsonPropertyName("name")]
    public string Name { get; set; }
        
    [JsonPropertyName("skybox")]
    public string Skybox { get; set; }
        
    [JsonPropertyName("blend-time")]
    public float BlendTime { get; set; }
        
    [JsonPropertyName("ambient-color")]
    public Color3 AmbientColor { get; set; }
        
    [JsonPropertyName("specular-color")]
    public Color3 SpecularColor { get; set; }
        
    [JsonPropertyName("upper-hemi-color")]
    public Color3 UpperHemiColor { get; set; }
        
    [JsonPropertyName("light-direction")]
    public Point3 LightDirection { get; set; }
        
    [JsonPropertyName("fog-near-min")]
    public float FogNearMin { get; set; }
        
    [JsonPropertyName("fog-far-min")]
    public float FogFarMin { get; set; }
        
    [JsonPropertyName("post-fog-solid-min")]
    public float PostFogSolidMin { get; set; }
        
    [JsonPropertyName("post-fog-fade-min")]
    public float PostFogFadeMin { get; set; }
        
    [JsonPropertyName("fog-near-max")]
    public float FogNearMax { get; set; }
        
    [JsonPropertyName("fog-far-max")]
    public float FogFarMax { get; set; }
        
    [JsonPropertyName("post-fog-solid-max")]
    public float PostFogSolidMax { get; set; }
        
    [JsonPropertyName("post-fog-fade-max")]
    public float PostFogFadeMax { get; set; }
        
    [JsonPropertyName("fog-color")]
    public Color3 FogColor { get; set; }
        
    [JsonPropertyName("directional-light-color")]
    public Color3 DirectionalLightColor { get; set; }

    [JsonPropertyName("templates")]
    public LevelTemplate[] Templates { get; set; }
        
    [JsonPropertyName("particles")]
    public Particle[] Particles { get; set; }
        
    [JsonPropertyName("triggers")]
    public Trigger[] Triggers { get; set; }
        
    [JsonPropertyName("scene-audio")]
    public SceneAudio SceneAudio { get; set; }
}