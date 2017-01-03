using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    public class BaseService<T> : IBaseService<T> where T : TEntity
    {
        ApplicationDbContext db;

        public BaseService(IApplicationDbContext db)
        {
            this.db = db as ApplicationDbContext;
        }

        public virtual T Create(T item)
        {
            T t = db.Set<T>().Add(item);
            SaveChanges();
            return t;
        }

        public T Get(int? id)
        {
            return db.Set<T>().Find(id);
        }
        public T Get(string id)
        {
            return db.Set<T>().Find(id);
        }

        public virtual void Edit(T item)
        {
            db.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Delete(int? id)
        {
            db.Set<T>().Remove(Get(id));
            SaveChanges();
        }

        public virtual void Delete(string id)
        {
            db.Set<T>().Remove(Get(id));
            SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(WebUser))
            {
                //return db.Set<ApplicationUser>().AsEnumerable<ApplicationUser>();
            }
            return db.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> func)
        {
            return db.Set<T>().Where(func);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}