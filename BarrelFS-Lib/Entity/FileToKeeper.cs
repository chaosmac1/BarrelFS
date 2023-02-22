using Cassandra;

namespace BarrelFS_Lib.Entity; 

public class FileToKeeper {
    public DateTime PartitionChunk { get; set; }
    public TimeUuid InternId { get; set; }
    public Guid KeeperId { get; set; }
}