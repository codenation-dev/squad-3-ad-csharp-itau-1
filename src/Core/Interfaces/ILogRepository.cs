using System.Collections.Generic;
using System.Linq;
using TryLog.Core.Model;

namespace TryLog.Core.Interfaces
{
    public interface ILogRepository : IDefaultRepository<Log>
    {
        IQueryable<Log> AsQueryable();
    }
}
