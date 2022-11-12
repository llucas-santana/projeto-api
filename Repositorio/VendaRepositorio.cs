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
    public class VendaRepositorio : BaseRepositorio<Venda>
    {
        public VendaRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Venda> listarTodos()
        {
            return base._contexto.Vendas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdIngressoNavigation).ToList();
        }

        public override List<Venda> listar(Expression<Func<Venda, bool>> expression)
        {
            return base._contexto.Vendas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdIngressoNavigation).Where(expression).ToList();
        }

        public override Venda recuperar(Expression<Func<Venda, bool>> expression)
        {
            return base._contexto.Vendas
                .Include(v => v.IdClienteNavigation)
                .Include(v => v.IdIngressoNavigation).Where(expression).SingleOrDefault();
        }

        public override void alterar(Venda obj)
        {
            base.alterar(obj);
        }

        public override void adicionar(Venda obj)
        {
            base.adicionar(obj);
        }

        public override void deletar(Venda obj)
        {
            base.deletar(obj);
        }
    }
}
