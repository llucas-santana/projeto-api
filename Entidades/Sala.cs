using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Sala
    {
        public Sala()
        {
            Ingressos = new HashSet<Ingresso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public bool? Ativo { get; set; }
        public int Quantidade { get; set; }

        public virtual ICollection<Ingresso> Ingressos { get; set; }
    }
}
