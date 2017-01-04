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
        // All int idied (non-ApplicationUser)
        T Create(T item);
        T Get(int? id);   
        void Edit(T item);
        void Delete(int? id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func);

        // All ApplicationUser-wise
        ApplicationUser Get(string id);
        ICollection<ApplicationUser> GetAll(string type);
        IQueryable<ApplicationUser> GetSolvers();
        ApplicationUser Find(string type, string id);
        void Delete(string id);
        System.Threading.Tasks.Task<string> GetUserRole();
        void SaveChanges();
    }
}