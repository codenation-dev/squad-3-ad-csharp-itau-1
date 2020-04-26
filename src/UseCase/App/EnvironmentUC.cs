using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.UseCase.DTO;
using TryLog.UseCase.Interfaces;
using Environment = TryLog.Core.Model.Environment;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace TryLog.UseCase.App
{
    public class EnvironmentUC : IEnvironmentUC
    {
        private readonly IEnvironmentRepository _repo;
        private readonly IMapper _mapper;
        public EnvironmentUC(IEnvironmentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public EnvironmentDTO Add(EnvironmentDTO entity)
        {
           var environment = _repo.Add(_mapper.Map<Environment>(entity));
            return _mapper.Map<EnvironmentDTO>(environment); 
        }

        public void Delete(int entityId)
        {
            _repo.Delete(x => x.Id == entityId);
        }

        public EnvironmentDTO Find(int entityId)
        {
            var entity = _repo.Find(x => x.Id == entityId);
            return _mapper.Map<EnvironmentDTO>(entity);
        }

        public List<EnvironmentDTO> FindAll(int entityId)
        {
            var entity = _repo.FindAll(x => x.Id == entityId);
            return _mapper.Map<List<EnvironmentDTO>>(entity);
        }

        public EnvironmentDTO Get(int entityId)
        {
            var entity = _repo.Get(entityId);
            return _mapper.Map<EnvironmentDTO>(entity);
        }

        public void SaveOrUpdate(EnvironmentDTO entityDTO)
        {
            _repo.Update(_mapper.Map<Environment>(entityDTO));
        }

        public List<EnvironmentDTO> SelectAll()
        {
            return _mapper.Map<List<EnvironmentDTO>>(_repo.SelectAll());
        }
    }
}
