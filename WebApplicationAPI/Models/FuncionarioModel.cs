using AutoMapper;
using Dados;
using Dados.EntityFramework;
using ObjetoTransferenciaDados;
using Repositorio;

namespace WebApplicationAPI.Models
{
    public class FuncionarioModel
    {
        public RetornoDTO<bool> salvar(FuncionarioDTO objDTO)
        {
            var retorno = new RetornoDTO<bool>();
            retorno.Status = true;

            try
            {
                if (objDTO != null)
                {
                    using (var contexto = new NovoProjeto2022Context())
                    {
                        var repositorio = new FuncionarioRepositorio(contexto);
                        Funcionario objEntidade = null;

                        var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                        objEntidade = mapper.Map<Funcionario>(objDTO);

                        if (objDTO.Id == 0)
                        {
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
                retorno.Mensagem = "Erro ao salvar o funcionario!";
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
                    var repositorio = new FuncionarioRepositorio(contexto);
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
                retorno.Mensagem = "Erro ao deletar o Funcionario";
            }

            return retorno;
        }

        public RetornoDTO<FuncionarioDTO> recuperar(int id)
        {
            var obj = new RetornoDTO<FuncionarioDTO>();
            obj.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var repositorio = new FuncionarioRepositorio(contexto);
                    Funcionario objEntidade = repositorio.recuperar(f => f.Id == id);

                    if (objEntidade != null)
                    {
                        obj.Resultado = new FuncionarioDTO
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

        public RetornoDTO<List<FuncionarioDTO>> listar()
        {
            var retorno = new RetornoDTO<List<FuncionarioDTO>>();
            retorno.Status = true;

            try
            {
                using (var contexto = new NovoProjeto2022Context())
                {
                    var mapper = new Mapper(AutoMapperConfig.RegisterMapper());
                    var repositorio = new FuncionarioRepositorio(contexto);
                    var listaEntidade = repositorio.listarTodos();
                    retorno.Resultado = mapper.Map<List<FuncionarioDTO>>(listaEntidade);
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
