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
    public class FilmeRepositorio : BaseRepositorio<Filme>
    {
        public FilmeRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        //public override List<Filme> listar(Expression<Func<Filme, bool>> expression)
        //{
        //    return base._contexto.Filmes
        //        .Include(f => f.IdEmpresaNavigation).Where(expression).ToList();
        //}

        //public override List<Filme> listarTodos()
        //{
        //    return base._contexto.Filmes
        //        .Include(f => f.IdEmpresaNavigation).ToList();
        //}

        //public override Filme recuperar(Expression<Func<Filme, bool>> expression)
        //{
        //    return base._contexto.Filmes
        //        .Include(f => f.IdEmpresaNavigation).Where(expression).SingleOrDefault();
        //}

        //public override void alterar(Filme obj)
        //{
        //    base.alterar(obj);
        //}

        //public override void adicionar(Filme obj)
        //{
        //    base.adicionar(obj);
        //}

        //public override void deletar(Filme obj)
        //{
        //    base.deletar(obj);
        //}
    }
}
