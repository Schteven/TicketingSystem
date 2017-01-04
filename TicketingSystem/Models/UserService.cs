using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    public class UserService : IUserService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public UserService()
        {
            db = new ApplicationDbContext();
        }
        public List<ApplicationUser> AllUsers()
        {
            var users = db.Users.Include(a => a.ManagerUser).OrderBy(u => u.PhoneNumber).ThenBy(u => u.Department).ToList();
            return users;
        }

        public ApplicationUser GetUser(string id)
        {

            ApplicationUser user = db.Users.Find(id);
            return user;

        }
    }
}