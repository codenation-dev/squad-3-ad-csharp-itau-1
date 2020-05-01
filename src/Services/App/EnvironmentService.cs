using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using Environment = TryLog.Core.Model.Environment;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

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

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public EnvironmentViewModel Find(int entityId)
        {
            var environment = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<EnvironmentViewModel>(environment);
        }

        public List<EnvironmentViewModel> FindAll(int entityId)
        {
            var environment = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<EnvironmentViewModel>>(environment);
        }

        public EnvironmentViewModel Get(int entityId)
        {
            var environment = _repo.Get(entityId);
            return _mapper.Map<EnvironmentViewModel>(environment);
        }

        public bool Update(EnvironmentViewModel entityDTO)
        {
            bool resultUpdate = _repo.Update(_mapper.Map<Environment>(entityDTO));
            return resultUpdate;
        }

        public List<EnvironmentViewModel> SelectAll()
        {
            return _mapper.Map<List<EnvironmentViewModel>>(_repo.SelectAll());
        }
    }
}
