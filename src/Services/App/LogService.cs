using AutoMapper;
using System.Collections.Generic;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

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
            entity.RegisterDate = DateTime.Now;
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

        public enum OrderFor
        {
            Level = 1, Descricao, Origem
        }
        /// <summary>
        /// Retorna Log's paginados
        /// </summary>
        /// <param name="search">Substring para procura no campo Log.Description</param>
        /// <param name="idsEnv">String numérica separada por virgulas.</param>
        /// <param name="order">Inteiro que indica o parâmetro para ordenação.</param>
        /// <param name="pageStart"></param>
        /// <param name="itemsPerPage"></param>
        /// <returns></returns>
        public PaginationViewModel<OutLogViewModel> SelectAll(string? search, string idsEnv = "1", int order = 1, int pageStart = 1, int itemsPerPage = 10)
        {
            idsEnv = string.IsNullOrEmpty(idsEnv) ? "1" : idsEnv;

            var ids = idsEnv.Split(",").Where(x => x != "," && !string.IsNullOrEmpty(x)).Select(int.Parse).ToList();

            var logs = _repo.AsQueryable();

            if (ids.Count > 0)
                logs = logs.Where(x => ids.Contains(x.IdEnvironment));

            if (!string.IsNullOrEmpty(search))
                logs = logs.Where(x => x.Description.ToLower().Contains(search.ToLower()));

            if (order != default)
            {
                switch (order)
                {
                    case 1: logs = logs.OrderBy(x => x.IdSeverity); break;
                    case 2: logs = logs.OrderBy(x => x.Description); break;
                    default: logs = logs.OrderBy(x => x.IdEnvironment); break;
                }
            }
            
            var logsBeforeSkip = logs;
            logs = logs.Skip((pageStart - 1) * itemsPerPage).Take(itemsPerPage);
            
            var pagination = new PaginationViewModel<OutLogViewModel>()

            {
                Data = _mapper.Map<List<OutLogViewModel>>(logs),
                Page = pageStart,
                PageSize = itemsPerPage,
                TotalItemCount = logsBeforeSkip.Count()                
            };
            return pagination;
        }
    }
}