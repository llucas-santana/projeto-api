using Dados.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public abstract class BaseRepositorio<T> where T : class
    {
        protected NovoProjeto2022Context _contexto;

        public BaseRepositorio(NovoProjeto2022Context contexto)
        {
            this._contexto = contexto;
        }

        public virtual List<T> listarTodos()
        {
            return this._contexto.Set<T>().ToList();
        }

        public virtual List<T> listar(Expression<Func<T, bool>> expression)
        {
            return this._contexto.Set<T>().Where(expression).ToList();
        }

        public virtual T recuperar(Expression<Func<T, bool>> expression)
        {
            return this._contexto.Set<T>().Where(expression).SingleOrDefault();
        }

        public virtual void adicionar(T obj)
        {
            this._contexto.Set<T>().Add(obj);
        }

        public virtual void deletar(T obj)
        {
            this._contexto.Entry(obj).State = EntityState.Deleted;
        }

        public virtual void alterar(T obj)
        {
            this._contexto.Entry(obj).State = EntityState.Modified;
        }
    }
}
