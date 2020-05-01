using System.Collections.Generic;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;


namespace TryLog.Services
{
    public class StatusManagerService
    {
        private readonly IStatusRepository _repoStatus;
        public StatusManagerService(IStatusRepository statusRepository)
        {
            _repoStatus = statusRepository;
        }

        public List<Status> GetStatusActives()
        {
            return _repoStatus.FindAll(x => x.Description != "ARQUIVADO" && x.Description != "APAGADO").ToList();
        }

    }
}
