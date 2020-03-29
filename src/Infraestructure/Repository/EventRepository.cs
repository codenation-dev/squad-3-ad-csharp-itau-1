using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using TryLog.Core.Entities;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.Model;

namespace TryLog.Infraestructure.Repository
{
    class EventRepository : IEventRepository
    {
        public void Delete(Event entity)
        {
            throw new NotImplementedException();
        }

        public List<Event> Find(Expression<Func<Event, bool>> predicate)
        {
            throw new NotImplementedException();
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
