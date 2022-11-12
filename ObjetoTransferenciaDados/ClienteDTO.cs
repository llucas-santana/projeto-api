using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public bool? Ativo { get; set; }

        public PessoaDTO IdPessoaNavigation { get; set; } = null!;
    }
}
