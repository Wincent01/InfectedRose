using System.ComponentModel.DataAnnotations.Schema;

namespace InfectedRose.Examples
{
    [Table("ZoneSummary")]
    public class ZoneSummary
    {
        [Column("zoneId")] public int ZoneId { get; set; }
        
        [Column("type")] public int Type { get; set; }
        
        [Column("value")] public int Value { get; set; }
        
        [Column("_uniqueID")] public int UniqueId { get; set; }
    }
}