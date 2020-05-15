using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class LogRepository : AbstractRepository<Log>, ILogRepository
    {
        public LogRepository(TryLogContext context) : base(context)
        {
        }

        public IQueryable<Log> AsQueryable()
        {
            return _context.Log.AsQueryable();
        }
        public override List<Log> FindAll(Expression<Func<Log, bool>> predicate)
        {
            return _context.Log.Include(x => x.Status).Include(x => x.Severity).Include(x => x.Environment).Include(x => x.Layer).Where(predicate).ToList();
            //return base.FindAll(predicate);
        }
    }
}
