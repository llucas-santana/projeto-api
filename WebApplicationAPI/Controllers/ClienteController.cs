using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public RetornoDTO<ClienteDTO> Get(int id)
        {
            var model = new ClienteModel();
            return model.recuperar(id);
        }

        [HttpPost]
        public RetornoDTO<bool> Post(ClienteDTO obj)
        {
            var model = new ClienteModel();
            return model.salvar(obj);
        }

        [HttpPut]
        public RetornoDTO<bool> Put(ClienteDTO obj)
        {
            var model = new ClienteModel();
            return model.salvar(obj);
        }

        [HttpDelete]
        public RetornoDTO<bool> Delete(int id)
        {
            var model = new ClienteModel();
            return model.deletar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<ClienteDTO>> Listar()
        {
            var model = new ClienteModel();
            return model.listar();
        }
    }
}
