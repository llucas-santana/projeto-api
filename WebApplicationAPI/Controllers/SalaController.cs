using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        [HttpGet]
        public RetornoDTO<SalaDTO> Get(int id)
        {
            var model = new SalaModel();
            return model.recuperar(id);
        }

        [HttpPost]
        public RetornoDTO<bool> Post(SalaDTO obj)
        {
            var model = new SalaModel();
            return model.salvar(obj);
        }

        [HttpPut]
        public RetornoDTO<bool> Put(SalaDTO obj)
        {
            var model = new SalaModel();
            return model.salvar(obj);
        }

        [HttpDelete]
        public RetornoDTO<bool> Delete(int id)
        {
            var model = new SalaModel();
            return model.deletar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<SalaDTO>> Listar()
        {
            var model = new SalaModel();
            return model.listar();
        }
    }
}
