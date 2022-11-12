using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObjetoTransferenciaDados;
using WebApplicationAPI.Models;

namespace WebApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private IWebHostEnvironment hostEnvironment;

        public FilmeController(IWebHostEnvironment environment)
        {
            this.hostEnvironment = environment;
        }

        [HttpPost]
        [Route("upload")]
        public string Upload([FromForm] FileUploadModel files)
        {
            var model = new FilmeModel();
            return model.salvarImagem(files, hostEnvironment);
        }

        [HttpGet]
        [Route("obterImagem")]
        public IActionResult ObterImagem(string arquivo)
        {
            var urlImagem = @"\uploads\" + arquivo;

            Byte[] fileImagem = System.IO.File
                .ReadAllBytes(@Directory.GetCurrentDirectory() + urlImagem);

            return File(fileImagem, "image/jpeg");
        }

        [HttpGet]
        public RetornoDTO<FilmeDTO> Get(int id)
        {
            var model = new FilmeModel();
            return model.recuperar(id);
        }

        [HttpPost]
        public RetornoDTO<bool> Post(FilmeDTO obj)
        {
            var model = new FilmeModel();
            return model.salvar(obj);
        }

        [HttpPut]
        public RetornoDTO<bool> Put(FilmeDTO obj)
        {
            var model = new FilmeModel();
            return model.salvar(obj);
        }

        [HttpDelete]
        public RetornoDTO<bool> Delete(int id)
        {
            var model = new FilmeModel();
            return model.deletar(id);
        }

        [HttpGet]
        [Route("listar")]
        public RetornoDTO<List<FilmeDTO>> Listar()
        {
            var model = new FilmeModel();
            return model.listar();
        }
    }
}
