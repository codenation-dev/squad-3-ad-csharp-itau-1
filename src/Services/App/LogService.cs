using AutoMapper;
using System.Collections.Generic;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;

namespace TryLog.Services.App
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;
        public LogService(ILogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        private LogViewModel Add(LogViewModel entity)
        {
            var log = _repo.Add(_mapper.Map<Log>(entity));
            return _mapper.Map<LogViewModel>(log);
        }

        public LogViewModel Add(LogViewModel entity, string token)
        {
            entity.Token = token;
            return Add(entity);
        }

        public void Delete(int entityId)
        {
            var log = _repo.Find(x => x.Id == entityId);
            log.Deleted = true;
            _repo.Update(log);
        }

        public LogViewModel Find(int entityId)
        {
            var log = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<LogViewModel>(log);
        }

        public List<LogViewModel> FindAll(int entityId)
        {
            var logs = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<LogViewModel>>(logs);
        }

        public LogViewModel Get(int entityId)
        {
            var xpto = _mapper.Map<LogViewModel>(null);
            var log = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            
            return _mapper.Map<LogViewModel>(log);
        }

        public bool Update(LogViewModel entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Log>(entity));
            return resultUpdate;
        }

        public List<LogViewModel> SelectAll()
        {
            var logs = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<LogViewModel>>(logs);
        }
        /*public List<LogViewModel> Filter()
        {
            //var logs = _repo.();
            return _mapper.Map<List<LogViewModel>>(logs);
        }*/
    }
}