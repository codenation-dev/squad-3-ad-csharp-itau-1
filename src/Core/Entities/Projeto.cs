using System;
using System.Collections.Generic;

namespace TryLog.Core.Entities
{
    public class Projeto
    {
        public long Id { get; set; }
        //Discutir necessidade desta prop
        public string Codigo { get; set; }
        //Discutir necessidade desta prop
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        //Discutir necessidade desta prop  
        public bool IsRemoved { get; set; }
    }
    public interface IProjeto
    {
        Projeto Create(string nome, string descricao);
        IEnumerable<Projeto> Get(Func<Projeto, bool> predicate);
        long Remove(Func<Projeto, bool> predicate);
    }
}
