using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;

namespace TryLog.UseCase
{
    public class LogManagerUC
    {
        private readonly ILogRepository _repoLog;
        public LogManagerUC(ILogRepository logRepository)
        {
            _repoLog = logRepository;
        }

        public Log SaveOrUpdate(Log log)
        {
            _repoLog.SaveOrUpdate(log);

            return log;
        }

        public void UpdateSeverity(long idLog, string updateSeverity)
        {
            var log = _repoLog.Find(x => x.Id == idLog).FirstOrDefault();

            log.Severity = new Severity()
            {
                Description = updateSeverity
            };
            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateEnviroment(long idLog, string updateEnviroment)
        {
            var log = _repoLog.Find(x => x.Id == idLog).FirstOrDefault();

            log.Environment = new Environment()
            {
                Description = updateEnviroment
            };
            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateLayer(long idLog, string updateLayer)
        {
            var log = _repoLog.Find(x => x.Id == idLog).FirstOrDefault();

            log.Layer = new Layer()
            {
                Description = updateLayer
            };
            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateStatus(long idLog, string updateStatus)
        {
            var log = _repoLog.Find(x => x.Id == idLog).FirstOrDefault();

            log.Status = new Status()
            {
                Description = updateStatus,
            };

            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateDeleted(long idLog, bool updateDeleted)
        {
            var log = _repoLog.Find(x => x.Id == idLog).FirstOrDefault();

            if (log.Deleted != updateDeleted)
            {
                log.Deleted = updateDeleted;
            }

            _repoLog.SaveOrUpdate(log);
        }
    }
}