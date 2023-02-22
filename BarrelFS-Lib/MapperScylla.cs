using Cassandra.Mapping;

namespace BarrelFS_Lib;

public class MapperScylla : Mappings {
    public MapperScylla() {
        For<Entity.DbVersion>()
            .TableName("db_version")
            .PartitionKey(x => x.Name)
            .Column(x => x.Name, cm => cm.WithName("name"))
            .Column(x => x.Version, cm => cm.WithName("version"))
            ;
        For<Entity.FileInfo>()
            .TableName("file_info")
            .PartitionKey(x => x.Time)
            .ClusteringKey(x => x.InternId)
            .Column(x => x.Time, x => x.WithName("time"))
            .Column(x => x.InternId, x => x.WithName("intern_id"))
            .Column(x => x.Name, x => x.WithName("name"))
            .Column(x => x.Size, x => x.WithName("size"))
            .Column(x => x.CreateTime, x => x.WithName("create_time"))
            .Column(x => x.Status, x => x.WithName("status"))
            ;
        For<Entity.FileName>()
            .TableName("file_name")
            .PartitionKey(x => x.Name)
            .Column(x => x.Name, x => x.WithName("name"))
            .Column(x => x.PublicId, x => x.WithName("public_id"))
            ;

        For<Entity.FileToKeeper>()
            .TableName("file_to_keeper")
            .PartitionKey(x => x.PartitionChunk)
            .ClusteringKey(x => x.InternId)
            .Column(x => x.PartitionChunk, x => x.WithName("partition_chunk"))
            .Column(x => x.InternId, x => x.WithName("intern_id"))
            .Column(x => x.KeeperId, x => x.WithName("keeper_id"))
            ;
        For<Entity.KeeperFile>()
            .TableName("keeper_file")
            .PartitionKey(x => x.KeeperId)
            .ClusteringKey(x => x.FileInfoId)
            .Column(x => x.KeeperId, x => x.WithName("keeper_id"))
            .Column(x => x.FileInfoId, x => x.WithName("file_info_id"))
            .Column(x => x.SplitNumber, x => x.WithName("split_number"))
            .Column(x => x.BarrelId, x => x.WithName("barrel_id"))
            .Column(x => x.Position, x => x.WithName("position"))
            .Column(x => x.Size, x => x.WithName("size"))
            ;
        For<Entity.KeeperInfo>()
            .TableName("keeper_info")
            .PartitionKey(x => x.KeeperId)
            .Column(x => x.KeeperId, x => x.WithName("keeper_id"))
            .Column(x => x.LastGc, x => x.WithName("last_gc"))
            .Column(x => x.Version, x => x.WithName("version"))
            .Column(x => x.MaxSize, x => x.WithName("max_size"))
            .Column(x => x.SizeNow, x => x.WithName("size_now"))
            .Column(x => x.Status, x => x.WithName("status"))
            .Column(x => x.CreateDate, x => x.WithName("create_date"))
            .Column(x => x.Rack, x => x.WithName("rack"))
            .Column(x => x.Region, x => x.WithName("region"))
            ;
        For<Entity.Log>()
            .TableName("log")
            .PartitionKey(x => x.Time)
            .Column(x => x.Time, x => x.WithName("time"))
            .Column(x => x.Id, x => x.WithName("id"))
            .Column(x => x.CreateTime, x => x.WithName("create_time"))
            .Column(x => x.Status, x => x.WithName("status"))
            .Column(x => x.Message, x => x.WithName("message"))
            ;
        For<Entity.PublicIntern>()
            .TableName("public_intern")
            .PartitionKey(x => x.ChunkPublicId)
            .ClusteringKey(x => x.PublicId)
            .Column(x => x.ChunkPublicId, x => x.WithName("chunk_public_id"))
            .Column(x => x.PublicId, x => x.WithName("public_id"))
            .Column(x => x.InternId, x => x.WithName("intern_id"))
            ;
        For<Entity.Settings>()
            .TableName("settings")
            .PartitionKey(x => x.Name)
            .Column(x => x.Name, x => x.WithName("name"))
            .Column(x => x.Value, x => x.WithName("value"))
            ;
        For<Entity.StatusQueue>()
            .TableName("status_queue")
            .PartitionKey("status")
            .Column(x => x.Status, x => x.WithName("status"))
            .Column(x => x.FileInfoId, x => x.WithName("file_info_id"))
            ;
    }
}




















