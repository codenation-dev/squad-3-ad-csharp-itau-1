using AutoMapper;
using System.Collections.Generic;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using System.Linq;

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
        //alterado add para public e incluido na interface para o teste funcionar
        public LogViewModel Add(LogViewModel entity)
        {
            var log = _repo.Add(_mapper.Map<Log>(entity));
            return _mapper.Map<LogViewModel>(log);
        }

        public LogViewModel Add(LogViewModel entity, string token)
        {
            entity.Token = token;
            return Add(entity);
        }

        public bool Delete(int entityId)
        {
            var log = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            
            if (log != null)
            {
                log.Deleted = true;
                return _repo.Update(log);
            }
            return false;
        }

        public LogViewModel Get(int entityId)
        {
            var log = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<LogViewModel>(log);
        }

        public bool Update(LogViewModel entity)
        {
            var log = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);

            if (log != null)
                return _repo.Update(_mapper.Map<Log>(entity));
           
            return false;
        }

        public PaginationViewModel<LogViewModel> SelectAll(int pageStart = 1, int itemsPerPage = 10)
        {
            var logs = _repo.FindAll(x => x.Deleted == false).Skip(pageStart-1*itemsPerPage).Take(itemsPerPage);
            var pagination = new PaginationViewModel<LogViewModel>()
            {
                Data = _mapper.Map<List<LogViewModel>>(logs),
                Page = pageStart,
                PageSize = itemsPerPage,
                TotalItemCount = _repo.Count()
            };
            return pagination;
        }
    }
}