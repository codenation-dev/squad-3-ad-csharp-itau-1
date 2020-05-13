using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Services.ViewModel;

namespace TryLog.Services.Interfaces
{
    public interface ISeverityService
    {
        SeverityViewModel Add(SeverityViewModel entity);
        SeverityViewModel Get(int entityId);
        bool Update(SeverityViewModel entity);
        bool Delete(int entityId);
        List<SeverityViewModel> SelectAll();
    }
}
