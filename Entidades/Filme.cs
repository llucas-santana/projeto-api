using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Filme
    {
        public Filme()
        {
            Ingressos = new HashSet<Ingresso>();
        }

        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int IdEmpresa { get; set; }
        public bool? Ativo { get; set; }
        public string Descricao { get; set; } = null!;
        public string Imagem { get; set; } = null!;
        public int DuracaoMinutos { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
        public virtual ICollection<Ingresso> Ingressos { get; set; }
    }
}
