using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface IStatusService
    {
        StatusViewModel Add(StatusViewModel entity);
        StatusViewModel Get(int entityId);
        StatusViewModel Find(int entityId);
        List<StatusViewModel> FindAll(int entityId);
        bool Update(StatusViewModel entity);
        void Delete(int entityId);
        List<StatusViewModel> SelectAll();
    }
}
