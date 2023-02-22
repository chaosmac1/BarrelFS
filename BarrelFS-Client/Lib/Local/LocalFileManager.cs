

using System.Threading.Channels;

namespace BarrelFS_Client.Lib.Local; 

public class LocalFileManager {
    private readonly LocalSettings Settings;

    
    
    public LocalFileManager(LocalSettings settings) {
        Channel<>
        Settings = settings;
    }



    
    public class LocalFileDataCh {
        
    }
}