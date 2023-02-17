using LamLibAllOver;

namespace BarrelFS_Client.Interface; 

public interface IBarrelFsClient: IDisposable {
    public Task<ResultErr<string>> CreateFileAsync(string name, Guid id, ref Span<byte> bytes);
    public Task<ResultErr<string>> CreateFileAsync(string name, Guid id, byte[] bytes);
    public Task<ResultErr<string>> CreateFileAsync(string name, Guid id, IReadOnlyList<byte> bytes);
    public Task<ResultErr<string>> CreateFileAsync(string name, Guid id, StreamReader bytes, long size);
    
    public Task<ResultErr<string>> ReplaceFileAsync(string name, Guid id, ref Span<byte> bytes);
    public Task<ResultErr<string>> ReplaceFileAsync(string name, Guid id, byte[] bytes);
    public Task<ResultErr<string>> ReplaceFileAsync(string name, Guid id, IReadOnlyList<byte> bytes);
    public Task<ResultErr<string>> ReplaceFileAsync(string name, Guid id, StreamReader bytes, long size);
    
    public Task<ResultErr<string>> ReplaceFileAsync(Guid id, ref Span<byte> bytes);
    public Task<ResultErr<string>> ReplaceFileAsync(Guid id, byte[] bytes);
    public Task<ResultErr<string>> ReplaceFileAsync(Guid id, IReadOnlyList<byte> bytes);
    public Task<ResultErr<string>> ReplaceFileAsync(Guid id, StreamReader bytes, long size);
    
    public Task<ResultErr<string>> RenameFileAsync(string name, Guid id);
    
    public Task<ResultErr<string>> DropFileAsync(Guid id);
    
    public Task<Result<, string>> FindFilesByNameAsync(string name);
    
    public Task<Result<, string>> FindFileByIdAsync(Guid id);
    
    public Task<Result<Guid[], string>> ExistFilesByNameAsync(string name);
    
    public Task<Result<bool, string>> ExistFileByIdAsync(Guid id);

    public Task<ResultErr<string>> Open();

    public Task<ResultErr<string>> Close();
}