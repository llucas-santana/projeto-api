using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class Venda
    {
        public int Id { get; set; }
        public int IdIngresso { get; set; }
        public DateTime DataVenda { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorPago { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Ingresso IdIngressoNavigation { get; set; } = null!;
    }
}
