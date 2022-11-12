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
    public class UsuarioRepositorio : BaseRepositorio<Usuario>
    {
        public UsuarioRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Usuario> listarTodos()
        {
            return base.listarTodos();
        }

        public override List<Usuario> listar(Expression<Func<Usuario, bool>> expression)
        {
            return base.listar(expression);
        }

        public override Usuario recuperar(Expression<Func<Usuario, bool>> expression)
        {
            return base.recuperar(expression);
        }

        public override void adicionar(Usuario obj)
        {
            base.adicionar(obj);
        }

        public override void alterar(Usuario obj)
        {
            base.alterar(obj);
        }

        public override void deletar(Usuario obj)
        {
            base.deletar(obj);
        }
    }
}
