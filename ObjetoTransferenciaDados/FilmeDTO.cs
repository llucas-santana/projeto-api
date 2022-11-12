using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class FilmeDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int IdEmpresa { get; set; }
        public bool? Ativo { get; set; }
        public string Descricao { get; set; } = null!;
        public string Imagem { get; set; } = null!;
        public int DuracaoMinutos { get; set; }

        //public Empresa IdEmpresaNavigation { get; set; } = null!;
    }
}
