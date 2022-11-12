using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Ingresso
    {
        public Ingresso()
        {
            Venda = new HashSet<Venda>();
        }

        public int Id { get; set; }
        public int IdFilme { get; set; }
        public int IdSala { get; set; }
        public bool? Ativo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }

        public virtual Filme IdFilmeNavigation { get; set; } = null!;
        public virtual Sala IdSalaNavigation { get; set; } = null!;
        public virtual ICollection<Venda> Venda { get; set; }
    }
}
