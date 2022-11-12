using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class FuncionarioDTO
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
         
        public PessoaDTO IdPessoaNavigation { get; set; } = null!;
    }
}
