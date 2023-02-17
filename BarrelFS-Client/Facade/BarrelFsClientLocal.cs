using System.Net;
using BarrelFS_Client.Interface;
using Cassandra;

namespace BarrelFS_Client.Facade;

public class BarrelFsClientLocal: IBarrelFsClient {
    private IPAddress _ipAddress;
    private IPEndPoint _ipEndPoint;
    private PlainTextAuthProvider _plainTextAuthProvider;
    private string _dbKeyspace;
    private string _directory;
    private string _storePath;

    internal BarrelFsClientLocal(IPAddress ipAddress, IPEndPoint ipEndPoint, PlainTextAuthProvider plainTextAuthProvider, string dbKeyspace, string directory, string storePath) {
        this._ipAddress = ipAddress;
        this._ipEndPoint = ipEndPoint;
        this._plainTextAuthProvider = plainTextAuthProvider;
        this._dbKeyspace = dbKeyspace;
        this._directory = directory;
        this._storePath = storePath;
    }
}