using System;

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
}
