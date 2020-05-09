using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ILogService
    {
        LogViewModel Add(LogViewModel entity, string token);
        LogViewModel Get(int entityId);
        LogViewModel Find(int entityId);
        List<LogViewModel> FindAll(int entityId);
        bool Update(LogViewModel entity);
        void Delete(int entityId);
        List<LogViewModel> SelectAll();
    }
}
