using System;
using System.Collections.Generic;

namespace TryLog.Core.Entities
{
    public class Evento : IEvento
    {
        public Evento()
        {
            DataCriacao = DateTime.Now;
        }
        
        /// <summary>
        /// Este Id serve para questóes de rastreabilidade da entidade.
        /// </summary>
        public long Id { get; private set; }

        //Talvez essas propriedades não sejam necessárias neste momento

        //public Projeto Sistema { get; set; }

        /// <summary>
        /// Indica a criticidade do evento
        /// </summary>
        public EnumSeveridade Severidade { get; private set; }

        public EnumPrioridade Prioridade { get; private set; }

        public Ambiente Ambiente { get; private set; }

        public Plataforma Plataforma { get; set; }

        /// <summary>
        /// Indica a situação do evento
        /// </summary>
        public EnumSituacao Situacao { get; private set; }

        /// <summary>
        /// Caso seja necessário vincular o Log à um Código Externo
        /// </summary>
        public string CodigoExterno { get; private set; }

        /// <summary>
        /// Campo que servirá como histórico para eventuais observações feita por quem analisará o log
        /// </summary>
        public string Descricao { get; private set; }

        /// <summary>
        /// Discutir com grupo a necessidade desta propriedade
        /// </summary>
        public string Metodo { get; private set; }

        /// <summary>
        /// ?
        /// </summary>
        public string Classe { get; private set; }

        /// <summary>
        /// Guardar aqui o rastreamento da pilha, talvez seja melhor, não?
        /// </summary>
        public string StackTrace { get; private set; }

        /// <summary>
        /// IP ? Cidade? O que devemos guardar aqui, precisamos desta propriedade?
        /// </summary>
        public string Localizacao { get; private set; }

        /// <summary>
        /// Data de criação do evento
        /// </summary>
        public DateTime DataCriacao { get; private set; }

        /// <summary>
        /// Indica quando o log
        /// </summary>
        public bool IsRemovido { get; private set; }

        public Evento Create(Usuario usuario, Plataforma plataforma, EnumSeveridade severiadade, EnumPrioridade prioridade, EnumSituacao situacao, string descricao = null, string codigoExterno = null, string localizacao = null, string stackTrace = null, string classe = null, string metodo = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> Get(Func<Evento, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public long Remove(Func<Evento, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Evento> Update(Func<Evento, bool> predicado, Evento usuarioAlterado)
        {
            throw new NotImplementedException();
        }
    }
    public interface IEvento
    {
        Evento Create(Usuario usuario, Plataforma plataforma, EnumSeveridade severiadade, EnumPrioridade prioridade, EnumSituacao situacao,
                       string descricao = null, string codigoExterno = null, string localizacao = null, string stackTrace = null,
                       string classe = null, string metodo = null
                      );
        IEnumerable<Evento> Get(Func<Evento, bool> predicate);
        long Remove(Func<Evento, bool> predicate);
        IEnumerable<Evento> Update(Func<Evento, bool> predicado, Evento usuarioAlterado);
    }
}
