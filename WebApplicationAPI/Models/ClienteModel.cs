using AutoMapper;
using Dados;
using Dados.EntityFramework;
using ObjetoTransferenciaDados;
using Repositorio;

namespace WebApplicationAPI.Models
{
    public class ClienteModel
    {
        public RetornoDTO<bool> salvar(ClienteDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                if (objDTO != null)
                {
                    using (var contexto = new NovoProjeto2022Context())
                    {
                        var repositorio = new ClienteRepositorio(contexto);
                        Cliente objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Cliente>(objDTO);

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
                retorno.Mensagem = "Erro ao salvar o cliente!";
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
                retorno.Mensagem = "Erro ao deletar o cliente";
            }

            return retorno;
        }

        public RetornoDTO<ClienteDTO> recuperar(int id)
        {
            var obj = new RetornoDTO<ClienteDTO>();
            obj.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new ClienteRepositorio(contexto);
                    Cliente objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {
                        obj.Resultado = new ClienteDTO
                        {
                            
                            Id = objEntidade.Id,   
                            IdPessoa = objEntidade.IdPessoa,
                            Login = objEntidade.Login,
                            Senha = objEntidade.Senha,
                            Ativo = objEntidade.Ativo
                        };

                        obj.Resultado.IdPessoaNavigation = new PessoaDTO
                        {
                            Id = objEntidade.IdPessoaNavigation.Id,
                            Cpf = objEntidade.IdPessoaNavigation.Cpf,
                            Nome = objEntidade.IdPessoaNavigation.Nome
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

        public RetornoDTO<List<ClienteDTO>> listar()
        {
            var retorno = new RetornoDTO<List<ClienteDTO>>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var repositorio = new ClienteRepositorio(contexto);
                    var listaEntidade = repositorio.listarTodos();
                    retorno.Resultado = mapper.Map<List<ClienteDTO>>(listaEntidade);
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
