using AutoMapper;
using Dados.EntityFramework;
using Dados;
using ObjetoTransferenciaDados;
using Repositorio;

namespace WebApplicationAPI.Models
{
    public class SalaModel
    {
        public RetornoDTO<bool> salvar(SalaDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                if (objDTO != null)
                {
                    using (var contexto = new NovoProjeto2022Context())
                    {
                        var repositorio = new SalaRepositorio(contexto);
                        Sala objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Sala>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar a sala!";
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
                    var repositorio = new SalaRepositorio(contexto);
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
                retorno.Mensagem = "Erro ao deletar a sala";
            }

            return retorno;
        }

        public RetornoDTO<SalaDTO> recuperar(int id)
        {
            var obj = new RetornoDTO<SalaDTO>();
            obj.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new SalaRepositorio(contexto);
                    Sala objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {
                        obj.Resultado = new SalaDTO
                        {
                            Id = objEntidade.Id,
                            Nome = objEntidade.Nome,
                            Ativo = objEntidade.Ativo,
                            Quantidade = objEntidade.Quantidade
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

        public RetornoDTO<List<SalaDTO>> listar()
        {
            var retorno = new RetornoDTO<List<SalaDTO>>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var repositorio = new SalaRepositorio(contexto);
                    var listaEntidade = repositorio.listarTodos();
                    retorno.Resultado = mapper.Map<List<SalaDTO>>(listaEntidade);
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
