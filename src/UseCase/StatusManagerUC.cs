using System.Collections.Generic;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;


namespace TryLog.UseCase
{
    public class StatusManagerUC
    {
        private readonly IStatusRepository _repoStatus;
        public StatusManagerUC(IStatusRepository statusRepository)
        {
            _repoStatus = statusRepository;
        }

        public List<Status> GetStatusActives()
        {
            return _repoStatus.FindAll(x => x.Description != "ARQUIVADO" && x.Description != "APAGADO").ToList();
        }

    }
}
