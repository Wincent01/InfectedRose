using System.Text.Json.Serialization;

namespace InfectedRose.Interface.Templates.ValueTypes;

public class PathData
{
    public class Waypoint
    {
        public class Config
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }
                
            [JsonPropertyName("value")]
            public DataValue Value { get; set; }
        }
            
        [JsonPropertyName("position")]
        public Point3 Position { get; set; }
            
        [JsonPropertyName("rotation")]
        public Point4? Rotation { get; set; }
            
        // Camera
        [JsonPropertyName("time")]
        public float? Time { get; set; }
            
        [JsonPropertyName("tension")]
        public float? Tension { get; set; }
            
        [JsonPropertyName("continuity")]
        public float? Continuity { get; set; }
            
        [JsonPropertyName("bias")]
        public float? Bias { get; set; }
            
        [JsonPropertyName("field-of-view")]
        public float? FieldOfView { get; set; }
            
        [JsonPropertyName("config")]
        public Config[]? Configuration { get; set; }
            
        // Moving platform
        [JsonPropertyName("lock-player")]
        public bool? LockPlayer { get; set; }
            
        [JsonPropertyName("speed")]
        public float? Speed { get; set; }
            
        [JsonPropertyName("wait")]
        public float? Wait { get; set; }
            
        [JsonPropertyName("depart-sound")]
        public string? DepartSound { get; set; }
            
        [JsonPropertyName("arrive-sound")]
        public string? ArriveSound { get; set; }
    }
        
    [JsonPropertyName("name")]
    public string Name { get; set; }
        
    [JsonPropertyName("type")]
    public string Type { get; set; }
        
    [JsonPropertyName("behavior")]
    public string Behavior { get; set; }
        
    [JsonPropertyName("waypoints")]
    public Waypoint[] Waypoints { get; set; }
        
    // Moving platform
    [JsonPropertyName("next-path")]
    public string? NextPath { get; set; }
        
    [JsonPropertyName("sound")]
    public string? Sound { get; set; }
        
    [JsonPropertyName("time-based")]
    public bool? TimeBased { get; set; }
        
    // Property
    [JsonPropertyName("price")]
    public int? Price { get; set; }
            
    [JsonPropertyName("rental-time")]
    public int? RentalTime { get; set; }
            
    [JsonPropertyName("associative-zone")]
    public string? AssociativeZone { get; set; }
            
    [JsonPropertyName("display-name")]
    public string? DisplayName { get; set; }
            
    [JsonPropertyName("display-description")]
    public string? DisplayDescription { get; set; }
            
    [JsonPropertyName("clone-limit")]
    public int? CloneLimit { get; set; }
            
    [JsonPropertyName("reputation-multiplier")]
    public float? ReputationMultiplier { get; set; }
            
    [JsonPropertyName("time-unit")]
    public string? TimeUnit { get; set; }
            
    [JsonPropertyName("achievement")]
    public string? Achievement { get; set; }
            
    [JsonPropertyName("player-zone-point")]
    public Point3? PlayerZonePoint { get; set; }
            
    [JsonPropertyName("max-build-height")]
    public float? MaxBuildHeight { get; set; }
        
    // Spawner
    [JsonPropertyName("spawned-id")]
    public string? SpawnedId { get; set; }
            
    [JsonPropertyName("respawn-time")]
    public float? RespawnTime { get; set; }
            
    [JsonPropertyName("max-spawn-count")]
    public int? MaxSpawnCount { get; set; }
            
    [JsonPropertyName("number-to-maintain")]
    public int? NumberToMaintain { get; set; }
            
    [JsonPropertyName("spawner-object")]
    public string? SpawnerObject { get; set; }
            
    [JsonPropertyName("activate-on-load")]
    public bool? ActivateOnLoad { get; set; }
}