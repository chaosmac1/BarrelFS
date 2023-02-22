using Cassandra;

namespace BarrelFS_Client.Lib.Local; 

public readonly struct LocalSettings {
    public readonly required string DbKeyspace { get; init; }
    public readonly required string Directory { get; init; }
    public readonly required string StorePath { get; init; }
    public readonly required Cluster Cluster { get; init; }
}