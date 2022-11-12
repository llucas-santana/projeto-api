using AutoMapper;
using Dados;
using ObjetoTransferenciaDados;

namespace WebApplicationAPI
{
    public class AutoMapperConfig : Profile
    {
        public static MapperConfiguration RegisterMapper()
        {
            var config = new MapperConfiguration(f =>
            {
                f.CreateMap<Cliente, ClienteDTO>();
                f.CreateMap<ClienteDTO, Cliente>();

                f.CreateMap<Empresa, EmpresaDTO>();
                f.CreateMap<EmpresaDTO, Empresa>();

                f.CreateMap<Filme, FilmeDTO>();
                f.CreateMap<FilmeDTO, Filme>();

                f.CreateMap<Funcionario, FuncionarioDTO>();
                f.CreateMap<FuncionarioDTO, Funcionario>();

                f.CreateMap<Ingresso, IngressoDTO>();
                f.CreateMap<IngressoDTO, Ingresso>();

                f.CreateMap<Pessoa, PessoaDTO>();
                f.CreateMap<PessoaDTO, Pessoa>();

                f.CreateMap<Sala, SalaDTO>();
                f.CreateMap<SalaDTO, Sala>();

                f.CreateMap<Usuario, UsuarioDTO>();
                f.CreateMap<UsuarioDTO, Usuario>();

                f.CreateMap<Venda, VendaDTO>();
                f.CreateMap<VendaDTO, Venda>();
            });

            return config; 
        }
    }
}
