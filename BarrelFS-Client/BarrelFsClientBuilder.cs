using System.Net;
using Cassandra;

namespace BarrelFS_Client; 

public class BarrelFsClientBuilder {
    internal BarrelFsClientBuilder() {
        
    }

    public BarrelFsClientBuilder CreateBuilder() => new();
    
    public BarrelFsClientBuilderLocal AsLocal() {
        return new();
    }

    public class BarrelFsClientBuilderLocal {
        private string? StorePath { get; set; }
        private string? Directory { get; set; }
        private IPAddress? IpAddress { get; set; } 
        private IPEndPoint? IpEndPoint { get; set; }
        private PlainTextAuthProvider? PlainTextAuthProvider { get; set; }
        private string? DbKeyspace { get; set; }

        internal BarrelFsClientBuilderLocal() { }

        public BarrelFsClientBuilderLocal SetIpAddress(IPAddress ipAddress) {
            this.IpAddress = ipAddress;
            return this;
        }
        public BarrelFsClientBuilderLocal SetIpEndPoint(IPEndPoint ipEndPoint) {
            this.IpEndPoint = ipEndPoint;
            return this;
        }
        public BarrelFsClientBuilderLocal SetPlainTextAuthProvider(PlainTextAuthProvider plainTextAuthProvider) {
            this.PlainTextAuthProvider = plainTextAuthProvider;
            return this;
        }
        public BarrelFsClientBuilderLocal SetDbKeyspace(string dbKeyspace) {
            this.DbKeyspace = dbKeyspace;
            return this;
        }
        public BarrelFsClientBuilderLocal SetDirectory(string directory) {
            this.Directory = directory;
            return this;
        }
        public BarrelFsClientBuilderLocal SetStorePath(string storePath) {
            this.StorePath = storePath;
            return this;
        }


        public IBarrelFsClient Build() {
            if (IpAddress is null)
                throw new NullReferenceException(nameof(IpAddress));
            if (IpEndPoint is null)
                throw new NullReferenceException(nameof(IpEndPoint));
            if (PlainTextAuthProvider is null)
                throw new NullReferenceException(nameof(PlainTextAuthProvider));
            if (DbKeyspace is null)
                throw new NullReferenceException(nameof(DbKeyspace));
            if (Directory is null)
                throw new NullReferenceException(nameof(Directory));
            if (StorePath is null)
                throw new NullReferenceException(nameof(StorePath));
            
            return new BarrelFsClientLocal(IpAddress, IpEndPoint, PlainTextAuthProvider, DbKeyspace, Directory, StorePath);
        }
    }
}