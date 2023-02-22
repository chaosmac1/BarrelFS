using System.Collections.Concurrent;
using System.Threading.Channels;
using LamLibAllOver;

namespace BarrelFS_Client.Lib.Local; 

public class LocalWriteManager {
    private readonly LocalSettings _settings;
    private Channel<LocalWriteDataCh>? _channel;
    private Thread? _thread;
    private bool _active;
    private CancellationToken _threadCanselToken;
    public bool IsActive => _active;
    private ConcurrentBag<Task> _bag = new();
    public LocalWriteManager(LocalSettings settings) {
        _settings = settings;
        this._thread = null;
        this._active = false;
        this._channel = null;
    }

    
    
    public class LocalWriteDataCh: LocalDataCh<FileInfo> {
        public required string Name { get; init; }
        public required Guid Id { get; init; }
        public required StreamReader Bytes { get; init; }
    }

    private async Task FlushClose() {
        _active = false;
        _threadCanselToken = new CancellationToken(true);
        
        if (_thread is null || _thread.IsAlive == false) {
            _thread = null;
            return;
        }
        try {
            _thread.Join(TimeSpan.FromMinutes(1));
        }
        catch (Exception) {
            // ignored
        }


        if (_thread is null || _thread.IsAlive == false) {
            _thread = null;
            return;
        }
        try {
            _thread.Interrupt();
        }
        catch (Exception) {
            // ignored
        }

        _thread = null;
    }

    private void RemoveFinishTask() {
        
    }
    private async Task Run() {
        ChannelReader<LocalWriteDataCh> reader = _channel!.Reader;
        if (this._threadCanselToken.IsCancellationRequested) {
            await FlushClose();
            return;
        }

        try {
            while (this._active) {
                if (this._threadCanselToken.IsCancellationRequested) {
                    await FlushClose();
                    return;
                }

                var localData = await reader.ReadAsync(this._threadCanselToken);
            }
        }
        catch (Exception e) {
            Console.WriteLine(e);
        }
        finally {
            this._active = false;
        }
    }
    
    public void Start() {
        if (_active) 
            throw new Exception("Can Not Start Then Is Active");
        
        this._threadCanselToken = new CancellationToken();
        _channel = System.Threading.Channels.Channel.CreateUnbounded<LocalWriteDataCh>(new UnboundedChannelOptions {
            SingleReader = true, 
            SingleWriter = false, 
            AllowSynchronousContinuations = false
        });
        _active = true;
        this._thread = new System.Threading.Thread(() => Run().Wait());
        this._thread.Start();
    }

    public void Close() {
        if (_active == false) return;
        FlushClose().Wait();
    }
}