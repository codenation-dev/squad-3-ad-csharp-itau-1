using AutoMapper;
using System.Collections.Generic;
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

        public bool Delete(int entityId)
        {
            var status = _repo.Find(x => x.Id == entityId && x.Deleted == false);

            if (status != null)
            {
                status.Deleted = true;
                return _repo.Update(status);
            }
            return false;
        }

        public StatusViewModel Get(int entityId)
        {
            var status = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<StatusViewModel>(status);
        }

        public bool Update(StatusViewModel entity)
        {
            var status = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);

            if (status != null)
                return _repo.Update(_mapper.Map<Status>(entity));
           
            return false;
        }

        public List<StatusViewModel> SelectAll()
        {
            var status = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<StatusViewModel>>(status);
        }
    }
}
