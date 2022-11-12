using AutoMapper;
using Dados;
using Dados.EntityFramework;
using ObjetoTransferenciaDados;
using Repositorio;
using System.Globalization;

namespace WebApplicationAPI.Models
{
    public class FilmeModel
    {
        public RetornoDTO<bool> salvar(FilmeDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                if (objDTO != null)
                {
                    using (var contexto = new NovoProjeto2022Context())
                    {
                        var repositorio = new FilmeRepositorio(contexto);
                        Filme objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Filme>(objDTO);

                        if (objDTO.Id == 0)
                        {
                            objEntidade.Ativo = true;
                            repositorio.adicionar(objEntidade);
                        }
                        else
                        {
                            repositorio.alterar(objEntidade);
                        }

                        contexto.SaveChanges();
                        retorno.Resultado = true;
                        retorno.Mensagem = "Salvo com sucesso!";
                    }
                }
            }
            catch (Exception ex)
            {
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao salvar o filme!";
                retorno.Status = false;
                retorno.Resultado = false;
            }

            return retorno;
        }

        public RetornoDTO<bool> deletar(int id)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new FilmeRepositorio(contexto);
                    var objEntidade = repositorio.recuperar(f => f.Id == id);
                    repositorio.deletar(objEntidade);
                    contexto.SaveChanges();
                    retorno.Resultado = true;
                    retorno.Mensagem = "Deletado com sucesso!";
                }
            }
            catch (Exception ex)
            {
                retorno.Status = false;
                retorno.Erro = ex.Message;
                retorno.Mensagem = "Erro ao deletar o filme";
            }

            return retorno;
        }

        public RetornoDTO<FilmeDTO> recuperar(int id)
        {
            var obj = new RetornoDTO<FilmeDTO>();
            obj.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new FilmeRepositorio(contexto);
                    Filme objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {
                        obj.Resultado = new FilmeDTO
                        {
                            Id = objEntidade.Id,
                            Nome = objEntidade.Nome,
                            IdEmpresa = objEntidade.IdEmpresa,
                            Descricao = objEntidade.Descricao,
                            Ativo = objEntidade.Ativo,
                            Imagem = objEntidade.Imagem,
                            DuracaoMinutos = objEntidade.DuracaoMinutos
                        };
                    }
                }
            }
            catch(Exception ex)
            {
                obj.Erro = ex.Message;
                obj.Status = false;
            }

            return obj;
        }

        public RetornoDTO<List<FilmeDTO>> listar()
        {
            var retorno = new RetornoDTO<List<FilmeDTO>>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var repositorio = new FilmeRepositorio(contexto);
                    var listaEntidade = repositorio.listarTodos();
                    retorno.Resultado = mapper.Map<List<FilmeDTO>>(listaEntidade);
                }
            }
            catch (Exception ex)
            {
                retorno.Status = false;
                retorno.Erro = ex.Message;
            }

            return retorno;
        }

        public string salvarImagem(FileUploadModel files, IWebHostEnvironment _enviroment)
        {
            if (files.files.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_enviroment.ContentRootPath + "\\uploads\\"))
                    {
                        Directory.CreateDirectory(_enviroment.ContentRootPath + "\\uploads\\");
                    }

                    var nomeArq = files.files.FileName.Split('.');
                    var novoNomeArquivo = Guid.NewGuid() + "." + nomeArq[nomeArq.Length - 1];

                    using(FileStream fileStream = System.IO.File.Create
                        (_enviroment.ContentRootPath + "\\uploads\\" + novoNomeArquivo))
                    {
                        files.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return novoNomeArquivo;
                    }
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return "Sem sucesso";
            }
        }
    }
}
