using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
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

        public LogViewModel Add(LogViewModel entity)
        {
            var log =_repo.Add(_mapper.Map<Log>(entity));
            return _mapper.Map<LogViewModel>(log);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
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
            var log = _repo.Get(entityId);
            return _mapper.Map<LogViewModel>(log);
        }

        public bool Update(LogViewModel entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Log>(entity));
            return resultUpdate;
        }

        public List<LogViewModel> SelectAll()
        {
            var logs = _repo.SelectAll();
            return _mapper.Map<List<LogViewModel>>(logs);
        }
    }
}
