using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class LogRepository : AbstractRepository<Log>, ILogRepository
    {
        public LogRepository(TryLogContext context) : base(context)
        {
        }


    }
}
