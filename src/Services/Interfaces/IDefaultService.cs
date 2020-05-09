using System;
using System.Collections.Generic;
using System.Text;

namespace TryLog.Services.Interfaces
{
    public interface IDefaultService<T>
    {
        T Add(T entity);
        T Get(int entityId);
        T Find(int entityId);
        List<T> FindAll(int entityId);
        bool Update(T entity);
        void Delete(int entityId);
        List<T> SelectAll();
    }
}
