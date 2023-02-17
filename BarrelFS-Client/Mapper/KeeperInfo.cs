namespace BarrelFS_Client.Mapper; 

public class KeeperInfo {
    public Guid KeeperId { get; set; }
    public DateTime LastGc { get; set; }
    public string? Version { get; set; }
    public long MaxSize { get; set; }
    public long SizeNow { get; set; }
    public string? Status { get; set; }
    public DateTime CreateDate { get; set; }
    public string? Rack { get; set; }
    public string? Region { get; set; }
}