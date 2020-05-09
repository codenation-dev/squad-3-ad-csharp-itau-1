using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Services.Interfaces;

namespace TryLog.Services.App
{
    public class AbstractService<T> : IDefaultService<T> where T : class
    {
        private readonly IDefaultRepository<T> _repo;
        private readonly IMapper _mapper;

        public AbstractService(IDefaultRepository<T> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public T Add(T entity)
        {
            return _repo.Add(entity);
        }

        public void Delete(int entityId)
        {
            throw new NotImplementedException();
        }

        public T Find(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<T> FindAll(int entityId)
        {
            throw new NotImplementedException();
        }

        public T Get(int entityId)
        {
            throw new NotImplementedException();
        }

        public List<T> SelectAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
