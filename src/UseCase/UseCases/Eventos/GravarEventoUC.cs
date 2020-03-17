using System;
using TryLog.Core.Entities;

namespace TryLog.UseCase.UseCases.Eventos
{
    public class GravarEventoUC
    {
        private IUsuario _user;
        private IEvento _event;
        private IAmbiente _ambiente;
        public GravarEventoUC(IUsuario usuario, IEvento evento, IAmbiente ambiente)
        {
            _user = usuario;
            _event = evento;
            _ambiente = ambiente;
        }
        
    }

    public interface IGravarEventoUC
    {
        bool GravarEvento(IEvento evento);
    }
}
