using System.Collections.Generic;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ILogService
    {
        LogViewModel Add(LogViewModel entity, string token);
        LogViewModel Get(int entityId);
        bool Update(LogViewModel entity);
        bool Delete(int entityId);
        List<LogViewModel> SelectAll();
    }
}
