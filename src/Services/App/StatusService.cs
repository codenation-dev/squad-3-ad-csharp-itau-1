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
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repo;
        private readonly IMapper _mapper;
        public StatusService(IStatusRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public StatusViewModel Add(StatusViewModel entity)
        {
            var status = _repo.Add(_mapper.Map<Status>(entity));
            return _mapper.Map<StatusViewModel>(status);
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public StatusViewModel Find(int entityId)
        {
            var status = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<StatusViewModel>(status);
        }

        public List<StatusViewModel> FindAll(int entityId)
        {
            var status = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<StatusViewModel>>(status);
        }

        public StatusViewModel Get(int entityId)
        {
            var status = _repo.Get(entityId);
            return _mapper.Map<StatusViewModel>(status);
        }

        public bool Update(StatusViewModel entity)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Status>(entity));
            return resultUpdate;
        }

        public List<StatusViewModel> SelectAll()
        {
            var status = _repo.SelectAll();
            return _mapper.Map<List<StatusViewModel>>(status);
        }
    }
}
