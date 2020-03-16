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

        public Ambiente GetAmbiente(Func<Ambiente, bool> predicate)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Cria novo ambiente
        /// </summary>
        /// <param name="Descricao"></param>
        /// <returns>Ambiente criado</returns>
        public Ambiente SetAmbiente(string Descricao)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Atualiza ambiente
        /// </summary>
        /// <param name="CodigoExterno"></param>
        /// <param name="Descricao"></param>
        /// <returns></returns>
        public Ambiente UpdateAmbiente(string CodigoExterno, string Descricao)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAmbiente
    {
        Ambiente Create(string Descricao);
        Ambiente Get(Func<Ambiente, bool> predicate);
        Ambiente Update(string CodigoExterno, string Descricao);
        bool Remove(Func<Ambiente, bool> predicate);
    }
}
