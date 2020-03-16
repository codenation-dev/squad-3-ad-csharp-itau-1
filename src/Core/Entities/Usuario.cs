using System;

namespace TryLog.Core.Entities
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Token { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool IsRemoved { get; set; }
    }
}
