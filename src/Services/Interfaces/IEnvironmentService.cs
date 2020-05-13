using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface IEnvironmentService
    {
        EnvironmentViewModel Add(EnvironmentViewModel entity);
        EnvironmentViewModel Get(int entityId);
        bool Update(EnvironmentViewModel entity);
        bool Delete(int entityId);
        List<EnvironmentViewModel> SelectAll();
    }
}