using System.Collections.Concurrent;
using System.Net;
using BarrelFS_Client.Interface;
using Cassandra;
using Cassandra.Mapping;
using LamLibAllOver;
using Org.BouncyCastle.Crypto.Generators;
using System.Threading.Channels;

namespace BarrelFS_Client.Facade;

public class BarrelFsClientLocal: IBarrelFsClient {
    private static readonly ConcurrentBag<BarrelFsClientLocal> _activeLocalClient = new();

    private readonly IPAddress _ipAddress;
    private readonly IPEndPoint _ipEndPoint;
    private readonly PlainTextAuthProvider _plainTextAuthProvider;
    private readonly string _dbKeyspace;
    private readonly string _directory;
    private readonly string _storePath;
    private Cluster? _cluster;

    private bool _open = false;
    private bool _newRequestAlloed = false;
    private Thread? _threadWrite = null;
    private Thread? _threadRead = null;
    private Thread? _threadFileHandle = null;

    internal BarrelFsClientLocal(IPAddress ipAddress, IPEndPoint ipEndPoint, PlainTextAuthProvider plainTextAuthProvider, string dbKeyspace, string directory, string storePath) {
        this._ipAddress = ipAddress;
        this._ipEndPoint = ipEndPoint;
        this._plainTextAuthProvider = plainTextAuthProvider;
        this._dbKeyspace = dbKeyspace;
        this._directory = directory;
        this._storePath = storePath;
                
        foreach (var barrelFsClientLocal in _activeLocalClient) {
            if (
                    Equals(_ipAddress, barrelFsClientLocal._ipAddress) && 
                    Equals(_ipEndPoint, barrelFsClientLocal._ipEndPoint) && 
                    _plainTextAuthProvider == barrelFsClientLocal._plainTextAuthProvider && 
                    _dbKeyspace == barrelFsClientLocal._dbKeyspace && 
                    _directory == barrelFsClientLocal._directory && 
                    _storePath == barrelFsClientLocal._storePath 
                )
                throw new Exception($"Can not Use new Client For Eq Work");
        }
    }

    public bool IsOpen() => _open;
    
    public void Dispose() {
        throw new NotImplementedException();
    }


    public async Task<Result<FileInfo, string>> CreateFileAsync(string name, Guid id, byte[] bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> CreateFileAsync(string name, Guid id, IReadOnlyList<byte> bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> CreateFileAsync(string name, Guid id, StreamReader bytes, long size,
        CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }


    public async Task<Result<FileInfo, string>> ReplaceFileAsync(string name, Guid id, byte[] bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> ReplaceFileAsync(string name, Guid id, IReadOnlyList<byte> bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> ReplaceFileAsync(string name, Guid id, StreamReader bytes, long size,
        CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, ref Span<byte> bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, byte[] bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, IReadOnlyList<byte> bytes, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, StreamReader bytes, long size, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<ResultErr<string>> RenameFileAsync(string name, Guid id, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<ResultErr<string>> DropFileAsync(Guid id, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> FindFilesByNameAsync(string name, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<FileInfo, string>> FindFileByIdAsync(Guid id, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<Guid[], string>> ExistFilesByNameAsync(string name, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<Result<bool, string>> ExistFileByIdAsync(Guid id, CancellationToken token = new CancellationToken()) {
        throw new NotImplementedException();
    }

    public async Task<ResultErr<string>> Open(CancellationToken token = new CancellationToken()) {
        if (token.IsCancellationRequested)
            return ResultErr<string>.Err("Token Cancellation");

        var thread = new Thread(() => { });
        thread.Start();
        thread.IsAlive
        
        
        this._cluster = BarrelFS_Lib.DbBuilder.Build(this._ipEndPoint, this._plainTextAuthProvider, this._dbKeyspace);
        System.Threading.Channels.Channel.CreateUnbounded<string>(new UnboundedChannelOptions()
            { SingleReader = true, SingleWriter = false });
        _open = true;
    }

    public async Task<ResultErr<string>> Close(CancellationToken token = new CancellationToken()) { 
        _open = false;
        _newRequestAlloed = false;
        _threadWrite = null;
        _threadRead = null;
        _threadFileHandle = null;
    }
    
    private static void ThreadChannelWrite() { }
    private static void ThreadChannelRead() { }
    private static void ThreadChannelHandle() { }
}