using System;
using System.Collections.Generic;

namespace TryLog.Core.Entities
{
    public class Plataforma : IPlataforma
    {
        public long Id { get; private set; }
        //Discutir necessidade desta prop
        public string CodigoExterno { get; private set; }
        public string Descricao { get; private set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        //Discutir necessidade desta prop  
        public bool IsRemoved { get; private set; }

        public IEnumerable<Plataforma> Get(Func<Plataforma, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Func<Plataforma, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Plataforma Create(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Plataforma> Update(Func<Plataforma, bool> predicado, string codigoExterno = null, string descricao = null)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlataforma
    {
        Plataforma Create(string codigo, string descricao);
        bool Remove(Func<Plataforma, bool> predicate);
        IEnumerable<Plataforma> Get(Func<Plataforma, bool> predicate);
        IEnumerable<Plataforma> Update(Func<Plataforma, bool> predicado, string codigoExterno = null, string descricao = null);
    }
}
