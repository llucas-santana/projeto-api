using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferenciaDados
{
    public class UsuarioDTO
    {

        private const string CHAVE_CLIENTE = "ee71df77-4be7-4003-a4a9-2c096b72ebff";
        private const string CHAVE_FUNCIONARIO = "c96ff8e5-2f6b-4722-a3eb-591caaa3b8b6";

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public string Papel { get; set; }
        public string Hash { get; set; }

        public static string obterHashCliente()
        {
            return CHAVE_CLIENTE;
        }

        public static string obterHashFuncionario()
        {
            return CHAVE_FUNCIONARIO;
        }
    }
}
