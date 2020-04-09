using System;
using System.Linq;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;

namespace TryLog.UseCase
{
    public class EventManagerUC
    {
        private readonly IEventRepository _repoEvent;
        public EventManagerUC(IEventRepository eventRepository)
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

        public Event SaveOrUpdate(long idEvent)
        {
            var evento = _repoEvent.Find(x => x.Id == idEvent).FirstOrDefault();

            if (evento.Id == idEvent)
            {
                throw new ArgumentException($"Event ID '{idEvent}' already exists.");
            }

            _repoEvent.SaveOrUpdate(evento);

            return evento;
        }
    }
}