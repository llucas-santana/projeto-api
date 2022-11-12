using AutoMapper;
using Dados.EntityFramework;
using Dados;
using ObjetoTransferenciaDados;
using Repositorio;

namespace WebApplicationAPI.Models
{
    public class IngressoModel
    {
        public RetornoDTO<bool> salvar(IngressoDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                if (objDTO != null)
                {
                    using (var contexto = new NovoProjeto2022Context())
                    {
                        var repositorio = new IngressoRepositorio(contexto);
                        Ingresso objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Ingresso>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar o ingresso!";
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
                    var repositorio = new ClienteRepositorio(contexto);
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
                retorno.Mensagem = "Erro ao deletar o ingresso";
            }

            return retorno;
        }

        public RetornoDTO<IngressoDTO> recuperar(int id)
        {
            var obj = new RetornoDTO<IngressoDTO>();
            obj.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new IngressoRepositorio(contexto);
                    Ingresso objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {
                        obj.Resultado = new IngressoDTO
                        {

                            Id = objEntidade.Id,
                            IdFilme = objEntidade.IdFilme,
                            IdSala = objEntidade.IdSala,
                            Valor = objEntidade.Valor,
                            DataInicio = objEntidade.DataInicio,
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

        public RetornoDTO<List<IngressoDTO>> listar()
        {
            var retorno = new RetornoDTO<List<IngressoDTO>>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var repositorio = new IngressoRepositorio(contexto);
                    var listaEntidade = repositorio.listarTodos();
                    retorno.Resultado = mapper.Map<List<IngressoDTO>>(listaEntidade);
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
