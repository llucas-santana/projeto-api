using Dados;
using Dados.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class PessoaRepositorio : BaseRepositorio<Pessoa>
    {
        public PessoaRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Pessoa> listarTodos()
        {
            return base.listarTodos();
        }

        public override List<Pessoa> listar(Expression<Func<Pessoa, bool>> expression)
        {
            return base.listar(expression);
        }

        public override Pessoa recuperar(Expression<Func<Pessoa, bool>> expression)
        {
            return base.recuperar(expression);
        }

        public override void alterar(Pessoa obj)
        {
            base.alterar(obj);
        }

        public override void adicionar(Pessoa obj)
        {
            base.adicionar(obj);
        }

        public override void deletar(Pessoa obj)
        {
            base.deletar(obj);
        }
    }
}
