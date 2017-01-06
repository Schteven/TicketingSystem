using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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

        // All non-ApplicationUser wise

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

        public virtual void Edit(T item)
        {
            db.Set<T>().AddOrUpdate(item);
            //db.Entry(item).State = EntityState.Modified;
            SaveChanges();
        }

        public virtual void Delete(int? id)
        {
            db.Set<T>().Remove(Get(id));
            SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Where(Expression<Func<T, bool>> func)
        {
            return db.Set<T>().Where(func);
        }


        // All ApplicationUser-wise

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationUser Get(string id)
        {
            return db.Users.Find(id);
        }

        public ICollection<ApplicationUser> GetAll(string type)
        {
            if (type == "ApplicationUser") {
                return db.Users.ToList();
            }
            return null;
        }

        public IQueryable<ApplicationUser> GetSolvers()
        {
            var solvers = db.Users.Where(u => u.Department.Contains("IT")).Where(m => m.ManagerUser.Department != "CEO");
            return solvers;
        }

        public ApplicationUser Find(string type, string id)
        {
            if (type == "ApplicationUser")
            {
                return db.Users.Find(id);
            }
            return null;
        }

        public virtual void Delete(string id)
        {
            db.Users.Remove(Get(id));
            SaveChanges();
        }

        public async System.Threading.Tasks.Task<string> GetUserRole()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityUserRole identityUserRole = UserManager.FindByName(HttpContext.Current.User.Identity.GetUserName()).Roles.FirstOrDefault();
            IdentityRole userRole = await roleManager.FindByIdAsync(identityUserRole.RoleId);

            return userRole.Name;
        }

        public IQueryable<ApplicationUser> GetUsersByRole(string roleName)
        {
            var role = (from r in db.Roles where r.Name.Contains(roleName) select r).FirstOrDefault();
            return db.Users.Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id));
        }

        // Global savechanges function
        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            Dispose(disposing);
        }

    }
}