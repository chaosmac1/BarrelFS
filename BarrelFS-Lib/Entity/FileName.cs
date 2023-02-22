using Cassandra;

namespace BarrelFS_Lib.Entity; 

public class FileName {
    public string? Name { get; set; }
    public Guid PublicId { get; set; }
}