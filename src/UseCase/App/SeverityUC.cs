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
    public class SeverityUC : ISeverityUC
    {
        private readonly ISeverityRepository _repo;
        private readonly IMapper _mapper;
        public SeverityUC(ISeverityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public void Add(SeverityDTO entity)
        {
            _repo.Add(_mapper.Map<Severity>(entity));
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public SeverityDTO Find(int entityId)
        {
            var entity = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<SeverityDTO>(entity);
        }

        public List<SeverityDTO> FindAll(int entityId)
        {
            var entity = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<SeverityDTO>>(entity);
        }

        public SeverityDTO Get(int entityId)
        {
            var entity = _repo.Get(entityId);
            return _mapper.Map<SeverityDTO>(entity);
        }

        public void SaveOrUpdate(SeverityDTO entity)
        {
            _repo.Update(_mapper.Map<Severity>(entity));
        }

        public List<SeverityDTO> SelectAll()
        {
            var entity = _repo.SelectAll();
            return _mapper.Map<List<SeverityDTO>>(entity);
        }
    }
}
