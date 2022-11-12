using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngressoController : ControllerBase
    {
        [HttpGet]
        public RetornoDTO<IngressoDTO> Get(int id)
        {
            var model = new IngressoModel();
            return model.recuperar(id);
        }

        [HttpPost]
        public RetornoDTO<bool> Post(IngressoDTO obj)
        {
            var model = new IngressoModel();
            return model.salvar(obj);
        }

        [HttpPut]
        public RetornoDTO<bool> Put(IngressoDTO obj)
        {
            var model = new IngressoModel();
            return model.salvar(obj);
        }

        [HttpDelete]
        public RetornoDTO<bool> Delete(int id)
        {
            var model = new IngressoModel();
            return model.deletar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<IngressoDTO>> Listar()
        {
            var model = new IngressoModel();
            return model.listar();
        }
    }
}
