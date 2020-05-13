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

        public bool Delete(int entityId)
        {
            bool resultDelete = false;
            var environment = _repo.Find(x => x.Id == entityId && x.Deleted == false);

            if (environment != null)
            {
                environment.Deleted = true;
                resultDelete = _repo.Update(environment);
            }

            return resultDelete;
        }

        public EnvironmentViewModel Get(int entityId)
        {
            var environment = _repo.Find(x => x.Id == entityId && x.Deleted == false);
            return _mapper.Map<EnvironmentViewModel>(environment);
        }

        public bool Update(EnvironmentViewModel entity)
        {
            bool resultUpdate = false;
            var environment = _repo.Find(x => x.Id == entity.Id && x.Deleted == false);
            
            if (environment != null)
            {
                resultUpdate = _repo.Update(_mapper.Map<Environment>(entity));
            }
            
            return resultUpdate;
        }

        public List<EnvironmentViewModel> SelectAll()
        {
            var environments = _repo.FindAll(x => x.Deleted == false);
            return _mapper.Map<List<EnvironmentViewModel>>(environments);
        }
    }
}
