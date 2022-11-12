using Dados.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using Repositorio;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("autenticar")]
        public ActionResult<dynamic> logar([FromBody] UsuarioDTO model)
        {
            bool valido = false;
            string caminho = "";
            ClienteRepositorio clienteRepositorio = null;
            FuncionarioRepositorio funcionarioRepositorio = null;

            using (NovoProjeto2022Context context = new NovoProjeto2022Context())
            {
                if (model.Papel == "cliente")
                {
                    clienteRepositorio = new ClienteRepositorio(context);

                    var cliente = clienteRepositorio.buscarPeloLoginESenha(model.Login, model.Senha);

                    if (cliente == null)
                    {
                        return Unauthorized(new
                        {
                            status = false,
                            mensagem = "Login ou Senha inválidos"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            status = true,
                            mensagem = "Login efetuado com sucesso",
                            token = Seguranca.gerarToken(model)
                        });

                    }
                }
                else
                {
                    funcionarioRepositorio = new FuncionarioRepositorio(context);
                    return null;
                }
            }
        }
    }
}
