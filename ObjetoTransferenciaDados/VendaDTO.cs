using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class VendaDTO
    {
        public int Id { get; set; }
        public int IdIngresso { get; set; }
        public DateTime DataVenda { get; set; }
        public int IdCliente { get; set; }
        public decimal ValorPago { get; set; }

        public ClienteDTO IdClienteNavigation { get; set; } = null!;
        public IngressoDTO IdIngressoNavigation { get; set; } = null!;
    }
}
