using System.Collections.Generic;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;

namespace TryLog.UseCase
{
    public class LogManagerUC
    {
        private readonly ILogRepository _repoLog;
        private readonly StatusManagerUC _statusManagerUC;
        public LogManagerUC(ILogRepository logRepository)
        {
            _repoLog = logRepository;
        }

        public Log SaveOrUpdate(Log log)
        {
            _repoLog.SaveOrUpdate(log);

            return log;
        }

        public void UpdateSeverity(short idLog, string updateSeverity)
        {
            var log = _repoLog.Find(x => x.Id == idLog);

            log.Severity = new Severity()
            {
                Description = updateSeverity
            };
            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateEnviroment(short idLog, string updateEnviroment)
        {
            var log = _repoLog.Find(x => x.Id == idLog);
            
            var env = log.Environment;

            log.Environment = new Environment(env.Id, log.Description, env.DateRegister);

            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateLayer(long idLog, string updateLayer)
        {
            var log = _repoLog.Find(x => x.Id == idLog);

            log.Layer = new Layer()
            {
                Description = updateLayer
            };
            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateStatus(long idLog, string updateStatus)
        {
            var log = _repoLog.Find(x => x.Id == idLog);

            log.Status = new Status()
            {
                Description = updateStatus,
            };

            _repoLog.SaveOrUpdate(log);
        }

        public void UpdateDeleted(long idLog, bool updateDeleted)
        {
            var log = _repoLog.Find(x => x.Id == idLog);

            if (log.Deleted != updateDeleted)
            {
                log.Deleted = updateDeleted;
            }

            _repoLog.SaveOrUpdate(log);
        }

        public List<Log> GetAll()
        {
            return _repoLog.FindAll(x => x.Deleted == false)
                           .OrderByDescending(x => x.DateRegister).ToList();
        }
    }
}