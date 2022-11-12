using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class SalaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!; 
        public bool? Ativo { get; set; }
        public int Quantidade { get; set; }
    }
}
