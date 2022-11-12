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
    public class SalaRepositorio : BaseRepositorio<Sala>
    {
        public SalaRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Sala> listarTodos()
        {
            return base.listarTodos();
        }

        public override List<Sala> listar(Expression<Func<Sala, bool>> expression)
        {
            return base.listar(expression);
        }

        public override Sala recuperar(Expression<Func<Sala, bool>> expression)
        {
            return base.recuperar(expression);
        }

        public override void adicionar(Sala obj)
        {
            base.adicionar(obj);
        }

        public override void deletar(Sala obj)
        {
            base.deletar(obj);
        }

        public override void alterar(Sala obj)
        {
            base.alterar(obj);
        }
    }
}
