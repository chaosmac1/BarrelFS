using Cassandra;

namespace BarrelFS_Lib.Entity; 

public class Log {
    public DateTime Time { get; set; }
    public TimeUuid Id { get; set; }
    public DateTime CreateTime { get; set; }
    public string? Status { get; set; }
    public string? Message { get; set; }
}