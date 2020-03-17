using System;
using System.Collections.Generic;

namespace TryLog.Core.Entities
{
    /// <summary>
    /// Refere-se ao ambiente para o qual um evento propagado.
    /// Exemplo: Produção, desenvolvimento ou teste.
    /// </summary>
    public sealed class Ambiente : IAmbiente
    {
        public long Id { get; set; }

        //Discutir necessidade desta prop
        public string CodigoExterno { get; set; }

        public string Descricao { get; set; }

        public bool IsAtivo { get; private set; }

        public DateTime DataCadastro { get; private set; }

        //Discutir necessidade desta prop
        public bool IsRemoved { get; private set; }

        /// <summary>
        /// Propriedade de navegação, que exibe todos eventos vinculados à este ambiente.
        /// </summary>
        public List<Evento> Eventos { get; }

        public Ambiente Create(string Descricao)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ambiente> Get(Func<Ambiente, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Func<Ambiente, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ambiente> Update(Func<Ambiente, bool> predicate, string CodigoExterno = null, string Descricao = null)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAmbiente
    {
        Ambiente Create(string Descricao);
        IEnumerable<Ambiente> Get(Func<Ambiente, bool> predicate);
        IEnumerable<Ambiente> Update(Func<Ambiente, bool> predicate, string CodigoExterno = null, string Descricao = null);
        bool Remove(Func<Ambiente, bool> predicate);
    }
}
