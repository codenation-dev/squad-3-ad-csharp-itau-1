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
        public StatusDTO Add(StatusDTO entity)
        {
            var status = _repo.Add(_mapper.Map<Status>(entity));
            return _mapper.Map<StatusDTO>(status);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public StatusDTO Find(int entityId)
        {
            var status = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<StatusDTO>(status);
        }

        public List<StatusDTO> FindAll(int entityId)
        {
            var status = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<StatusDTO>>(status);
        }

        public StatusDTO Get(int entityId)
        {
            var status = _repo.Get(entityId);
            return _mapper.Map<StatusDTO>(status);
        }

        public bool Update(StatusDTO entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Status>(entity));
            return resultUpdate;
        }

        public List<StatusDTO> SelectAll()
        {
            var status = _repo.SelectAll();
            return _mapper.Map<List<StatusDTO>>(status);
        }
    }
}
