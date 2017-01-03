using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TicketingSystem.Services;

namespace TicketingSystem.Models
{
    
    public class UserService : BaseService<WebUser>, IUserService
    {

        public UserService(IApplicationDbContext db) : base(db) 
        {

        }

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

        public List<WebUser> AllUsers()
        {

            //var users = db.Users.Include(a => a.ManagerUser).OrderBy(u => u.PhoneNumber).ThenBy(u => u.Department).ToList();
            //return users;
            return null;
            //var users = base.GetAll();
            //return users.ToList();
        }

        public WebUser GetUser(string id)
        {

            //WebUser user = db.Users.Find(id);
            //return user;
            return null;

        }

        public string GetUserRole(string userName)
        {
            /*var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityUserRole identityUserRole = UserManager.FindByName(userName).Roles.FirstOrDefault();
            IdentityRole userRole = await roleManager.FindByIdAsync(identityUserRole.RoleId);

            return userRole.Name;
            */
            return null;
        }
    }
}