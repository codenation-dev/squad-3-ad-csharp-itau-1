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
    public class StatusUC : IStatusUC
    {
        private readonly IStatusRepository _repo;
        private readonly IMapper _mapper;
        public StatusUC(IStatusRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public void Add(StatusDTO entity)
        {
            _repo.Add(_mapper.Map<Status>(entity));
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public StatusDTO Find(int entityId)
        {
            var entity = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<StatusDTO>(entity);
        }

        public List<StatusDTO> FindAll(int entityId)
        {
            var entity = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<StatusDTO>>(entity);
        }

        public StatusDTO Get(int entityId)
        {
            var entity = _repo.Get(entityId);
            return _mapper.Map<StatusDTO>(entity);
        }

        public void SaveOrUpdate(StatusDTO entity)
        {
            _repo.Update(_mapper.Map<Status>(entity));
        }

        public List<StatusDTO> SelectAll()
        {
            var entity = _repo.SelectAll();
            return _mapper.Map<List<StatusDTO>>(entity);
        }
    }
}
