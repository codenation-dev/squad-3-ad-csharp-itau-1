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

        public bool Delete(int entityId)
        {
            bool resultDelete = false;
            var severity = _repo.Find(x => x.Id == entityId && x.Deleted == false);

            if (severity != null)
            {
                severity.Deleted = true;
                resultDelete = _repo.Update(severity);
            }

            return resultDelete;
        }

        public SeverityViewModel Get(int entityId)
        {
            var severity = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<SeverityViewModel>(severity);
        }

        public bool Update(SeverityViewModel entity)
        {
            bool resultUpdate = false;
            var severity = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);

            if (severity != null)
            {
                resultUpdate = _repo.Update(_mapper.Map<Severity>(entity));
            }

            return resultUpdate;
        }

        public List<SeverityViewModel> SelectAll()
        {
            var severities = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<SeverityViewModel>>(severities);
        }
    }
}
