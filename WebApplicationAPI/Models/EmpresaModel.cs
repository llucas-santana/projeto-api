using AutoMapper;
using Dados;
using Dados.EntityFramework;
using ObjetoTransferenciaDados;
using Repositorio;

namespace WebApplicationAPI.Models
{
    public class EmpresaModel
    {
        public RetornoDTO<bool> salvar(EmpresaDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                if (objDTO != null)
                {
                    using (var contexto = new NovoProjeto2022Context())
                    {
                        var repositorio = new EmpresaRepositorio(contexto);
                        Empresa objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Empresa>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar a empresa!";
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
                    var repositorio = new EmpresaRepositorio(contexto);
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
                retorno.Mensagem = "Erro ao deletar a empresa";
            }

            return retorno;
        }

        public RetornoDTO<EmpresaDTO> recuperar(int id)
        {
            var obj = new RetornoDTO<EmpresaDTO>();
            obj.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new EmpresaRepositorio(contexto);
                    Empresa objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {
                        obj.Resultado = new EmpresaDTO
                        {
                            Id = objEntidade.Id,
                            Nome = objEntidade.Nome,
                            Ativo = objEntidade.Ativo
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                obj.Erro = ex.Message;
                obj.Status = false;
            }

            return obj;
        }

        public RetornoDTO<List<EmpresaDTO>> listar()
        {
            var retorno = new RetornoDTO<List<EmpresaDTO>>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var repositorio = new EmpresaRepositorio(contexto);
                    var listaEntidade = repositorio.listarTodos();
                    retorno.Resultado = mapper.Map<List<EmpresaDTO>>(listaEntidade);
                }
            }
            catch (Exception ex)
            {
                retorno.Status = false;
                retorno.Erro = ex.Message;
            }

            return retorno;
        }
    }
}
