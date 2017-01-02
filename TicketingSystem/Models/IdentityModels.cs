using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace TicketingSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Cellnumber { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; }

        public virtual string Manager { get; set; }
        [ForeignKey("Manager")]
        public virtual ApplicationUser ManagerUser { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Issue> Issues { get; set; }
        public DbSet<IssueReply> IssueReplies { get; set; }
        public DbSet<IssueStatus> IssueStatuses { get; set; }
        public DbSet<IssueManager> IssueManagers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }

}