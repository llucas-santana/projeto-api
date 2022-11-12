using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Funcionario
    {
        public Funcionario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int Id { get; set; }
        public int IdPessoa { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
