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
    public class EmpresaRepositorio : BaseRepositorio<Empresa>
    {
        public EmpresaRepositorio(NovoProjeto2022Context contexto)
            : base(contexto)
        {

        }

        public override List<Empresa> listarTodos()
        {
            return base.listarTodos();
        }

        public override List<Empresa> listar(Expression<Func<Empresa, bool>> expression)
        {
            return base.listar(expression);
        }

        public override Empresa recuperar(Expression<Func<Empresa, bool>> expression)
        {
            return base.recuperar(expression);
        }

        public override void adicionar(Empresa obj)
        {
            base.adicionar(obj);
        }

        public override void deletar(Empresa obj)
        {
            base.deletar(obj);
        }

        public override void alterar(Empresa obj)
        {
            base.alterar(obj);
        }
    }
}
