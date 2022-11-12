using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Papel { get; set; } = null!;
        public bool Ativo { get; set; }
        public int IdFuncionario { get; set; }

        public virtual Funcionario IdFuncionarioNavigation { get; set; } = null!;
    }
}
