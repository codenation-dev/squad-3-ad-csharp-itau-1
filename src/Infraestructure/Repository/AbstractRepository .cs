using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public abstract class AbstractRepository<T> : IDefaultRepository<T> where T : class
    {
        private readonly TryLogContext _context;
        public AbstractRepository(TryLogContext context)
        {
            _context = context;
        }
        public T Add(T entity)
        {
           T resultEntity = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return resultEntity;
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            T entity = _context.Set<T>().Where(predicate).FirstOrDefault();
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                 .Where(predicate)
                 .FirstOrDefault();
        }
        public List<T> FindAll(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>()
                 .Where(predicate)
                 .ToList();
        }
        public T Get(int entityId)
        {
            return _context.Set<T>().Find(entityId);
        }

        public bool Update(T entity)
        {
            _ =_context.Set<T>().Update(entity);           
            return _context.SaveChanges() == 1;
        }

        public List<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}