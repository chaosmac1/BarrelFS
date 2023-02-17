namespace BarrelFS_Client.Mapper; 

public class KeeperFile {
    public Guid KeeperId { get; set; }
    public Guid FileInfoId { get; set; }
    public Guid BarrelId { get; set; }
    public long Id { get; set; }
    public long Position { get; set; }
    public long Size { get; set; }
}