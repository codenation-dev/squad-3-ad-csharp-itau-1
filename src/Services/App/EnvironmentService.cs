using AutoMapper;
using System.Collections.Generic;
using TryLog.Core.Interfaces;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Services.App
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly IEnvironmentRepository _repo;
        private readonly IMapper _mapper;
        public EnvironmentService(IEnvironmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public EnvironmentViewModel Add(EnvironmentViewModel entity)
        {
           var environment = _repo.Add(_mapper.Map<Environment>(entity));
            return _mapper.Map<EnvironmentViewModel>(environment); 
        }

        public bool Delete(int entityId)
        {
            var environment = _repo.Find(x => x.Id == entityId && x.Deleted == false);

            if (environment != null)
            {
                environment.Deleted = true;
                return _repo.Update(environment);
            }
            return false;
        }

        public EnvironmentViewModel Get(int entityId)
        {
            var environment = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<EnvironmentViewModel>(environment);
        }

        public bool Update(EnvironmentViewModel entity)
        {
            var environment = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);
            
            if (environment != null)
                return _repo.Update(_mapper.Map<Environment>(entity));
            
            return false;
        }

        public List<EnvironmentViewModel> SelectAll()
        {
            var environments = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<EnvironmentViewModel>>(environments);
        }
    }
}
