using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ILogService
    {
        LogViewModel Add(LogViewModel entity);
        LogViewModel Get(int entityId);
        LogViewModel Find(int entityId);
        List<LogViewModel> FindAll(int entityId);
        bool Update(LogViewModel entity);
        void Delete(int entityId);
        List<LogViewModel> SelectAll();
    }
}
