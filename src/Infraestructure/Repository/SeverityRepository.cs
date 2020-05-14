using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class SeverityRepository : AbstractRepository<Severity>, ISeverityRepository
    {
        public SeverityRepository(TryLogContext context) : base(context)
        {
        }
    }
}
