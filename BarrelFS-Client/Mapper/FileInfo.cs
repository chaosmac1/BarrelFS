using Cassandra;

namespace BarrelFS_Client.Mapper; 

public class FileInfo {
    public DateTime Time { get; set; }
    public TimeUuid Id { get; set; }
    public string? Name { get; set; }
    public long Size { get; set; }
    public DateTime CreateTime { get; set; }
    public string? Status { get; set; }
}