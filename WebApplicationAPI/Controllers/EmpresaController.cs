using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        public RetornoDTO<EmpresaDTO> Get(int id)
        {
            var model = new EmpresaModel();
            return model.recuperar(id);
        }

        [HttpPost]
        public RetornoDTO<bool> Post(EmpresaDTO obj)
        {
            var model = new EmpresaModel();
            return model.salvar(obj);
        }

        [HttpPut]
        public RetornoDTO<bool> Put(EmpresaDTO obj)
        {
            var model = new EmpresaModel();
            return model.salvar(obj);
        }

        [HttpDelete]
        public RetornoDTO<bool> Delete(int id)
        {
            var model = new EmpresaModel();
            return model.deletar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<EmpresaDTO>> Listar()
        {
            var model = new EmpresaModel();
            return model.listar();
        }
    }
}
