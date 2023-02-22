using LamLibAllOver;

namespace BarrelFS_Client.Lib.Local; 

public abstract class LocalDataCh<T> {
    private readonly EventWaitHandle _ewh;
    private Result<T, string> _value;
    
    public LocalDataCh() {
        _ewh = new EventWaitHandle(true, EventResetMode.ManualReset);
        _value = Result<T, string>.Empty;
    }

    public void SetResultValue(Result<T, string> value) {
        this._value = value;
        _ewh.Set();
    } 
        
    public Result<T, string> WaitResult() {
        _ewh.WaitOne();
        return this._value;
    }
}