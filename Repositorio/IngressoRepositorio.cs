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
    public class IngressoRepositorio : BaseRepositorio<Ingresso>
    {
        public IngressoRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Ingresso> listarTodos()
        {
            return base._contexto.Ingressos
                .Include(i => i.IdSalaNavigation)
                .Include(i => i.IdFilmeNavigation).ToList();
        }

        public override List<Ingresso> listar(Expression<Func<Ingresso, bool>> expression)
        {
            return base._contexto.Ingressos
                .Include(i => i.IdSalaNavigation)
                .Include(i => i.IdFilmeNavigation).Where(expression).ToList();
        }

        public override Ingresso recuperar(Expression<Func<Ingresso, bool>> expression)
        {
            return base._contexto.Ingressos
                .Include(i => i.IdSalaNavigation)
                .Include(i => i.IdFilmeNavigation).Where(expression).SingleOrDefault();
        }

        public override void alterar(Ingresso obj)
        {
            base.alterar(obj);
        }

        public override void adicionar(Ingresso obj)
        {
            base.adicionar(obj);
        }

        public override void deletar(Ingresso obj)
        {
            base.deletar(obj);
        }
    }
}
