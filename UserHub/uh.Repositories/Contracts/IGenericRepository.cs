using System;
using System.Linq;
using System.Linq.Expressions;

namespace uh.Repositories.Contracts
{
    public interface IGenericRepository<T>
    {
        T FindById(int id);

        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
