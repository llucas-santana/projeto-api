using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Pessoa
    {
        public Pessoa()
        {
            Clientes = new HashSet<Cliente>();
            Funcionarios = new HashSet<Funcionario>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public string Cpf { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Funcionario> Funcionarios { get; set; }
    }
}
