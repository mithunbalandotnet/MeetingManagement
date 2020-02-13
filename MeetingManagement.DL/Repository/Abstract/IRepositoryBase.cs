using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MeetingManagement.DL.Repository.Abstract
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties);

        T GetById(int id);

        void Create(T entity);
        void Update(T entity);
        bool Delete(int id);
    }
}
