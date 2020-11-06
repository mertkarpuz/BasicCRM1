using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace BasicCrm.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
