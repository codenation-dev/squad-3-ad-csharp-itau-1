

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;

namespace TryLog.Infraestructure.Repository
{
    public class EventRepository : AbstractRepository<Event>, IEventRepository
    {
        public EventRepository(TryLogContext context) : base(context)
        {
        }
        public void Create(Event @event)
        {
            Add(@event);
        }
        public Event Read(long eventId)
        {
            return Get(eventId);
        }
        public List<Event> Filter(Expression<Func<Event, bool>> predicate)
        {
            return Find(predicate);
        }
        public void Remove(Expression<Func<Event, bool>> predicate)
        {
            Delete(predicate);
        }
        public void Update(Event @event)
        {
            SaveOrUpdate(@event);
        }
    }
}
