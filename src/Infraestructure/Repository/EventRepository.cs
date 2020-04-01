using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Core.Model;
using TryLog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using TryLog.Infraestructure.EF;
using System.Linq;

namespace TryLog.Infraestructure.Repository
{
    public class EventRepository : IEventRepository
    {
        TryLogContext _dbContext;
        public EventRepository(TryLogContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Event entity)
        {
            _dbContext.Events.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Event entity)
        {
            _dbContext.Events.Remove(entity);
            _dbContext.SaveChanges();
        }

        public List<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            return _dbContext.Events.Where(predicate).ToList();
        }

        public Event Get(Event entity)
        {
            throw new NotImplementedException();
        }

        public void SaveOrUpdate(Event entity)
        {
            throw new NotImplementedException();
        }
    }
}
