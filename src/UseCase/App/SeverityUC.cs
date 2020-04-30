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
        public SeverityDTO Add(SeverityDTO entity)
        {
            var severity = _repo.Add(_mapper.Map<Severity>(entity));
            return _mapper.Map<SeverityDTO>(severity);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public SeverityDTO Find(int entityId)
        {
            var severity = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<SeverityDTO>(severity);
        }

        public List<SeverityDTO> FindAll(int entityId)
        {
            var severities = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<SeverityDTO>>(severities);
        }

        public SeverityDTO Get(int entityId)
        {
            var severity = _repo.Get(entityId);
            return _mapper.Map<SeverityDTO>(severity);
        }

        public bool Update(SeverityDTO entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Severity>(entity));
            return resultUpdate;
        }

        public List<SeverityDTO> SelectAll()
        {
            var severities = _repo.SelectAll();
            return _mapper.Map<List<SeverityDTO>>(severities);
        }
    }
}
