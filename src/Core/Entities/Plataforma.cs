using System;

namespace TryLog.Core.Entities
{
    public class Plataforma
    {
        public Plataforma()
        {
        }
        public long Id { get; private set; }
        //Discutir necessidade desta prop
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        //Discutir necessidade desta prop  
        public bool IsRemoved { get; private set; } 
    }

    public interface Plataforma
    {
        Plataforma SetPlataforma(string Codigo, string Descricao);
    }
}
