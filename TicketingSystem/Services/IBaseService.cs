using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using TicketingSystem.Models;

namespace TicketingSystem.Services
{
    public interface IBaseService<T> where T : TEntity
    {
        T Create(T item);
        T Get(int? id);
        T Get(string id);
        void Edit(T item);
        void Delete(int? id);
        void Delete(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func);
        void SaveChanges();
    }
}