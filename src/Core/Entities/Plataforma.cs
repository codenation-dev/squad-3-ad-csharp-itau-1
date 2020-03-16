using System;

namespace TryLog.Core.Entities
{
    public class Plataforma : IPlataforma
    {
        public long Id { get; private set; }
        //Discutir necessidade desta prop
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        //Discutir necessidade desta prop  
        public bool IsRemoved { get; private set; }

        public Plataforma GetPlataforma(Func<Plataforma, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Func<Plataforma, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Plataforma SetPlataforma(string codigo, string descricao)
        {
            throw new NotImplementedException();
        }
    }

    public interface IPlataforma
    {
        Plataforma SetPlataforma(string codigo, string descricao);
        bool Remove(Func<Plataforma, bool> predicate);
        Plataforma GetPlataforma(Func<Plataforma, bool> predicate);
    }
}
