using Cassandra;

namespace BarrelFS_Lib.Entity; 

public class KeeperFile {
    public Guid KeeperId { get; set; }
    public TimeUuid FileInfoId { get; set; }
    public long SplitNumber { get; set; } 
    public Guid BarrelId { get; set; }
    public long Position { get; set; }
    public long Size { get; set; }
}