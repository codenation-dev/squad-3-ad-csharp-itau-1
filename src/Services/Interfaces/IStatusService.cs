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
        bool Update(StatusViewModel entity);
        bool Delete(int entityId);
        List<StatusViewModel> SelectAll();
    }
}
