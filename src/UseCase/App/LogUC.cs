using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.UseCase.DTO;
using TryLog.UseCase.Interfaces;

namespace TryLog.UseCase.App
{
    public class LogUC : ILogUC
    {
        private readonly ILogRepository _repo;
        private readonly IMapper _mapper;
        public LogUC(ILogRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public LogDTO Add(LogDTO entity)
        {
            var log =_repo.Add(_mapper.Map<Log>(entity));
            return _mapper.Map<LogDTO>(log);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public LogDTO Find(int entityId)
        {
            var log = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<LogDTO>(log);
        }

        public List<LogDTO> FindAll(int entityId)
        {
            var logs = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<LogDTO>>(logs);
        }

        public LogDTO Get(int entityId)
        {
            var log = _repo.Get(entityId);
            return _mapper.Map<LogDTO>(log);
        }

        public bool Update(LogDTO entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Log>(entity));
            return resultUpdate;
        }

        public List<LogDTO> SelectAll()
        {
            var logs = _repo.SelectAll();
            return _mapper.Map<List<LogDTO>>(logs);
        }
    }
}
