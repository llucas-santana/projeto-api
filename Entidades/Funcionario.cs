using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Funcionario
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public bool Ativo { get; set; }

        public virtual Pessoa IdPessoaNavigation { get; set; } = null!;
    }
}
