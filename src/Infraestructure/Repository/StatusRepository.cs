using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class StatusRepository : AbstractRepository<Status>, IStatusRepository
    {
        public StatusRepository(TryLogContext context) : base(context)
        {
        }
    }
}
