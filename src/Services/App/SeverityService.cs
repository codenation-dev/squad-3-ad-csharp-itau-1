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
    public class SeverityService : ISeverityService
    {
        private readonly ISeverityRepository _repo;
        private readonly IMapper _mapper;
        public SeverityService(ISeverityRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public SeverityViewModel Add(SeverityViewModel entity)
        {
            var severity = _repo.Add(_mapper.Map<Severity>(entity));
            return _mapper.Map<SeverityViewModel>(severity);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public SeverityViewModel Find(int entityId)
        {
            var severity = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<SeverityViewModel>(severity);
        }

        public List<SeverityViewModel> FindAll(int entityId)
        {
            var severities = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<SeverityViewModel>>(severities);
        }

        public SeverityViewModel Get(int entityId)
        {
            var severity = _repo.Get(entityId);
            return _mapper.Map<SeverityViewModel>(severity);
        }

        public bool Update(SeverityViewModel entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Severity>(entity));
            return resultUpdate;
        }

        public List<SeverityViewModel> SelectAll()
        {
            var severities = _repo.SelectAll();
            return _mapper.Map<List<SeverityViewModel>>(severities);
        }
    }
}
