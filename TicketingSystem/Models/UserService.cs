using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IApplicationDbContext db) : base(db)
        {
        }

        public List<ApplicationUser> AllUsers()
        {
            var users = base.GetAll("ApplicationUser");
            return users.ToList();
        }

        public IQueryable<ApplicationUser> Solvers()
        {
            var solvers = base.GetSolvers();
            return solvers;
        }

        public ApplicationUser GetUser(string id)
        {

            ApplicationUser user = base.Find("ApplicationUser", id);
            return user;

        }

        public new async System.Threading.Tasks.Task<string> GetUserRole()
        {
            string userRole = await base.GetUserRole();
            return userRole;
        }
    }
}