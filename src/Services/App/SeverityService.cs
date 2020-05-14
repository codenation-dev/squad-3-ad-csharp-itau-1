using AutoMapper;
using System.Collections.Generic;
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

        public bool Delete(int entityId)
        {
            var severity = _repo.Find(x => x.Id == entityId && x.Deleted == false);

            if (severity != null)
            {
                severity.Deleted = true;
                return _repo.Update(severity);
            }
            return false;
        }

        public SeverityViewModel Get(int entityId)
        {
            var severity = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<SeverityViewModel>(severity);
        }

        public bool Update(SeverityViewModel entity)
        {
            var severity = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);

            if (severity != null)
                return _repo.Update(_mapper.Map<Severity>(entity));
            
            return false;
        }

        public List<SeverityViewModel> SelectAll()
        {
            var severities = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<SeverityViewModel>>(severities);
        }
    }
}
