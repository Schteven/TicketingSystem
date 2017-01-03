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
using System.ComponentModel.DataAnnotations;
using System.Resources;

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
        [Display(Name = "UserName", ResourceType = typeof(App_GlobalResources.globalUI))]
        public override string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(App_GlobalResources.globalUI))]
        public override string Email { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public override string PhoneNumber { get; set; }

        [Display(Name="Firstname", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Firstname { get; set; }

        [Display(Name = "Lastname", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Lastname { get; set; }

        [Display(Name = "Cellnumber", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Cellnumber { get; set; }

        [Display(Name = "Department", ResourceType = typeof(App_GlobalResources.globalUI))]
        public string Department { get; set; }

        public bool IsActive { get; set; }
        [Display(Name = "Manager", ResourceType = typeof(App_GlobalResources.globalUI))]
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