using System;
using System.Collections.Generic;

namespace TryLog.Core.Entities
{
    public class Usuario
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Token { get; private set; }
        public bool IsAtivo { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public bool IsRemoved { get; private set; }
    }
    public interface IUsuario
    {
        Usuario Create(string email, string nome, string senha);
        IEnumerable<Usuario> Get(Func<Usuario, bool> predicate);
        long Remove(Func<Usuario, bool> predicate);

    }
}
