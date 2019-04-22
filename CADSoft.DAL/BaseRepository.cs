using CADSoft.Entity;
using CADSoft.Entity.ComContext;
using CADSoft.Entity.DBContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CADSoft.DAL
{
    public class BaseRepository<T, TContext> where T : BaseModel, IEntity
        where TContext : DbContext
    {
        private TContext dataContext;
        private readonly IDbSet<T> dbSet;

        protected BaseRepository(TContext context)
        {
            dataContext = context;
            dbSet = context.Set<T>();
        }

        public virtual T Add(T entity)
        {
            dbSet.Add(entity);
            dataContext.SaveChanges();
            return entity;
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual void SoftDelete(int id)
        {
            T entity = dbSet.Find(id);
            entity.IsDeleted = true;
            Update(entity);
        }

        public virtual void HardDelete(T entity)
        {
            dbSet.Remove(entity);
            dataContext.SaveChanges();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                SoftDelete(obj.ID);
        }

        public virtual T GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbSet.ToList();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).ToList();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbSet.Where(where).FirstOrDefault<T>();
        }
    }
}
