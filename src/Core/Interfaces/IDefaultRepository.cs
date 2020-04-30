using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace TryLog.Core.Interfaces
{
    public interface IDefaultRepository<T>
    {
        T Add(T entity);
        T Get(int entityId);
        T Find(Expression<Func<T, bool>> predicate);
        List<T> FindAll(Expression<Func<T, bool>> predicate);
        bool Update(T entity);
        void Delete(Expression<Func<T, bool>> predicate);
        List<T> SelectAll();

    }
}
