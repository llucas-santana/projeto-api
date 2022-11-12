using Dados;
using Dados.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class FuncionarioRepositorio : BaseRepositorio<Funcionario>
    {
        public FuncionarioRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Funcionario> listarTodos()
        {
            return base._contexto.Funcionarios
                .Include(f => f.IdPessoaNavigation).ToList();
        }

        public override List<Funcionario> listar(Expression<Func<Funcionario, bool>> expression)
        {
            return base._contexto.Funcionarios
                .Include(f => f.IdPessoaNavigation).Where(expression).ToList();
        }

        public override Funcionario recuperar(Expression<Func<Funcionario, bool>> expression)
        {
            return base._contexto.Funcionarios
                .Include(f => f.IdPessoaNavigation).Where(expression).SingleOrDefault();
        }

        public override void alterar(Funcionario obj)
        {
            base.alterar(obj);
            this._contexto.Entry(obj.IdPessoaNavigation).State = EntityState.Modified;
        }

        public override void adicionar(Funcionario obj)
        {
            base.adicionar(obj);
            this._contexto.Entry(obj.IdPessoaNavigation).State = EntityState.Added;
        }

        public override void deletar(Funcionario obj)
        {
            base.deletar(obj);
            this._contexto.Entry(obj.IdPessoaNavigation).State = EntityState.Deleted;
        }

        public Funcionario buscarPeloLoginESenha(string login, string senha)
        {
            return null;

            //return this._contexto.Funcionarios.Where<Funcionario>(c => c.Login.Equals(login) & c.Senha.Equals(senha)).FirstOrDefault();
        }
    }
}
