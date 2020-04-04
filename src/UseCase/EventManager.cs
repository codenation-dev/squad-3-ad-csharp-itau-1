using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using System.Linq;

namespace TryLog.UseCase
{
   
    public class EventManager
    {
        private readonly IEventRepository _repoEvent;
        public EventManager(IEventRepository eventRepository)
        {
            _repoEvent = eventRepository;
        }
        public void UpdateStatus(string IdEvent, string updateStatus)
        {
            long.TryParse(IdEvent, out var IdEventLong);
            //var evento = _repoEvent.Find(x => x.Id == IdEventLong).FirstOrDefault();

            /*evento.Status = new Core.Model.Status()
            {
                Description = updateStatus,
            };
            
            _repoEvent.SaveOrUpdate(evento);*/
        }
    }
}
