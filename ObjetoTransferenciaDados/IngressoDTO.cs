using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class IngressoDTO
    {
        public int Id { get; set; }
        public int IdFilme { get; set; }
        public int IdSala { get; set; }
        public bool? Ativo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInicio { get; set; }

        //public Filme IdFilmeNavigation { get; set; } = null!;
        //public Sala IdSalaNavigation { get; set; } = null!;
    }
}
