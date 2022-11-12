using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [HttpGet]
        public RetornoDTO<FuncionarioDTO> Get(int id)
        {
            var model = new FuncionarioModel();
            return model.recuperar(id);
        }

        [HttpPost]
        public RetornoDTO<bool> Post(FuncionarioDTO obj)
        {
            var model = new FuncionarioModel();
            return model.salvar(obj);
        }

        [HttpPut]
        public RetornoDTO<bool> Put(FuncionarioDTO obj)
        {
            var model = new FuncionarioModel();
            return model.salvar(obj);
        }

        [HttpDelete]
        public RetornoDTO<bool> Delete(int id)
        {
            var model = new FuncionarioModel();
            return model.deletar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<FuncionarioDTO>> Listar()
        {
            var nome = User.Identity.Name;

            var model = new FuncionarioModel();
            return model.listar();
        }
    }
}
