using System.Net;
using Cassandra;
using Cassandra.Mapping;

namespace BarrelFS_Lib; 

public static class DbBuilder {
    public static Cluster Build(IPEndPoint point, PlainTextAuthProvider plainTextAuthProvider, string keyspace) {
        return Cassandra.Cluster.Builder()
                .AddContactPoints(point)
                // .AddContactPoints(Env.ScyllaIpv4.Select(x => new IPEndPoint(IPAddress.Parse(x), port)).ToArray())
                .WithAuthProvider(plainTextAuthProvider)
                .WithDefaultKeyspace(keyspace)
                .WithPoolingOptions(new PoolingOptions()
                        .SetWarmup(true)
                        .SetCoreConnectionsPerHost(HostDistance.Local,2)
                        .SetHeartBeatInterval(200)
                    // .SetMaxConnectionsPerHost(HostDistance.Local, 200)
                    // // .SetMaxConnectionsPerHost(HostDistance.Local, 10000)
                    // // .SetMaxConnectionsPerHost(HostDistance.Remote, 10000)
                    // .SetMinSimultaneousRequestsPerConnectionTreshold(HostDistance.Local, 20)
                    // .SetMinSimultaneousRequestsPerConnectionTreshold(HostDistance.Remote, 2)
                )
                .WithQueryOptions(new QueryOptions().SetConsistencyLevel(ConsistencyLevel.One))
                .WithSocketOptions(new SocketOptions().SetTcpNoDelay(true).SetStreamMode(true).SetKeepAlive(true))
                .WithLoadBalancingPolicy(new RoundRobinPolicy())
                .WithReconnectionPolicy(new ConstantReconnectionPolicy(50))
                .WithMonitorReporting(false)
                .Build()
            ;
    }

    public static Mapper GetMapper(Cluster cluster) {
        var session = cluster.Connect();

        return new Mapper(session);
    } 
}