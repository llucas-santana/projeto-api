using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Empresa
    {
        public Empresa()
        {
            Filmes = new HashSet<Filme>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool Ativo { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
