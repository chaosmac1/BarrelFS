using Cassandra;

namespace BarrelFS_Lib.Entity; 

public class FileInfo {
    public DateTime Time { get; set; }
    public TimeUuid InternId { get; set; }
    public string? Name { get; set; }
    public long Size { get; set; }
    public DateTime CreateTime { get; set; }
    public string? Status { get; set; }
}