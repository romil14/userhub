﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace uh.Interfaces.Common
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
