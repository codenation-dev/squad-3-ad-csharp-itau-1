using System;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.EF;
using System.Linq.Expressions;
using System.Collections.Generic;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.Infraestructure.Repository
{
    public class EnvironmentRepository : AbstractRepository<Environment>, IEnvironmentRepository
    {
        public EnvironmentRepository(TryLogContext context):base(context)
        {
        }
        public void Create(Environment Environment)
        {
            Add(Environment);
        }
        public Environment Read(long EnvironmentId)
        {
            return Get(EnvironmentId);
        }
        public List<Environment> Filter(Expression<Func<Environment, bool>> predicate)
        {
            return Find(predicate);
        }
        public void Remove(Expression<Func<Environment, bool>> predicate)
        {
            Delete(predicate);
        }
        public void Update(Environment Environment)
        {
            SaveOrUpdate(Environment);
        }
    }
}
