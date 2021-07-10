using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uh.Entities.Context;
using uh.Interfaces.Common;

namespace uh.Repositories.Common
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected RepositoryContext _repositoryContext;
        public GenericRepository(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public void Create(T entity)
        {
            this._repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            this._repositoryContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return this._repositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            this._repositoryContext.Set<T>().Update(entity);
        }

        public T FindById(int id)
        {
            return this._repositoryContext.Set<T>().Find(id);
        }

       
    }
}
