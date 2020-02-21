using MeetingManagement.DL.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MeetingManagement.DL.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, IEntityBase
    {
        private readonly MeetingDBContext _dbContext;

        public RepositoryBase(MeetingDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeProperties)
        {
            var query = _dbContext.Set<T>();

            foreach (var expression in includeProperties)
            {
                query.Include(expression);
            }

            return query;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Where(e => e.ID == id).FirstOrDefault();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Create(T entity)
        {
            _dbContext.Add<T>(entity);
            _dbContext.SaveChanges();
        }

        public bool Delete(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
