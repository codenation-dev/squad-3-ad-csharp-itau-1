using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class StatusRepository : AbstractRepository<Status>, IStatusRepository
    {
        public StatusRepository(TryLogContext context) : base(context)
        {
        }
        
        public void Create(Status status)
        {
            Add(status);
        }
        public Status Read(long statusId)
        {
            return Get(statusId);
        }
        public List<Status> Filter(Expression<Func<Status, bool>> predicate)
        {
            return Find(predicate);
        }
        public void Remove(Expression<Func<Status, bool>> predicate)
        {
            Delete(predicate);
        }
        public void Update(Status status)
        {
            SaveOrUpdate(status);
        }
    }
}
