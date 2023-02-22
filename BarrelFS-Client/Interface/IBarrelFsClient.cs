using LamLibAllOver;

namespace BarrelFS_Client.Interface; 

public interface IBarrelFsClient: IDisposable {
    public Task<Result<FileInfo, string>> CreateFileAsync(string name, Guid id, byte[] bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> CreateFileAsync(string name, Guid id, IReadOnlyList<byte> bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> CreateFileAsync(string name, Guid id, StreamReader bytes, long size, CancellationToken token = new());
    
    public Task<Result<FileInfo, string>> ReplaceFileAsync(string name, Guid id, byte[] bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> ReplaceFileAsync(string name, Guid id, IReadOnlyList<byte> bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> ReplaceFileAsync(string name, Guid id, StreamReader bytes, long size, CancellationToken token = new());
    
    public Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, ref Span<byte> bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, byte[] bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, IReadOnlyList<byte> bytes, CancellationToken token = new());
    public Task<Result<FileInfo, string>> ReplaceFileAsync(Guid id, StreamReader bytes, long size, CancellationToken token = new());
    
    public Task<ResultErr<string>> RenameFileAsync(string name, Guid id, CancellationToken token = new());
    
    public Task<ResultErr<string>> DropFileAsync(Guid id, CancellationToken token = new());
    
    public Task<Result<FileInfo, string>> FindFilesByNameAsync(string name, CancellationToken token = new());
    
    public Task<Result<FileInfo, string>> FindFileByIdAsync(Guid id, CancellationToken token = new());
    
    public Task<Result<Guid[], string>> ExistFilesByNameAsync(string name, CancellationToken token = new());
    
    public Task<Result<bool, string>> ExistFileByIdAsync(Guid id, CancellationToken token = new());

    public Task<ResultErr<string>> Open(CancellationToken token = new());

    public Task<ResultErr<string>> Close(CancellationToken token = new());
}