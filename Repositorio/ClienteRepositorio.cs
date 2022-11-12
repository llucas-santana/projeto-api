using Dados;
using Dados.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ClienteRepositorio : BaseRepositorio<Cliente>
    {
        public ClienteRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Cliente> listarTodos()
        {
            return base._contexto.Clientes
                .Include(c => c.IdPessoaNavigation).ToList();
        }

        public override List<Cliente> listar(Expression<Func<Cliente, bool>> expression)
        {
            return base._contexto.Clientes
                .Include(c => c.IdPessoaNavigation).Where(expression).ToList();
        }

        public override Cliente recuperar(Expression<Func<Cliente, bool>> expression)
        {
            return base._contexto.Clientes
                .Include(c => c.IdPessoaNavigation).Where(expression).SingleOrDefault();
        }

        public override void alterar(Cliente obj)
        {
            base.alterar(obj);
            this._contexto.Entry(obj.IdPessoaNavigation).State = EntityState.Modified;
        }

        public override void adicionar(Cliente obj)
        {
            base.adicionar(obj);
            this._contexto.Entry(obj.IdPessoaNavigation).State = EntityState.Added;      
        }

        public override void deletar(Cliente obj)
        {
            base.deletar(obj);
            this._contexto.Entry(obj.IdPessoaNavigation).State = EntityState.Deleted;
        }

        public Cliente buscarPeloLoginESenha(string login, string senha)
        {
            return this._contexto.Clientes.Where<Cliente>(c => c.Login.Equals(login) & c.Senha.Equals(senha)).FirstOrDefault();
        }
    }
}
